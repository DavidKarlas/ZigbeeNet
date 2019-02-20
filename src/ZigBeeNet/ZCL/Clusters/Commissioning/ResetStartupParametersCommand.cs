﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Commissioning;

/**
 * Reset Startup Parameters Command value object class.
 *
 * Cluster: Commissioning. Command is sentTO the server.
 * This command is a specific command used for the Commissioning cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Commissioning
{
       public class ResetStartupParametersCommand : ZclCommand
       {
           /**
           * Option command message field.
           */
           public byte Option { get; set; }

           /**
           * Index command message field.
           */
           public byte Index { get; set; }


           /**
           * Default constructor.
           */
           public ResetStartupParametersCommand()
           {
               GenericCommand = false;
               ClusterId = 21;
               CommandId = 3;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Option, ZclDataType.Get(DataType.BITMAP_8_BIT));
            serializer.Serialize(Index, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Option = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.BITMAP_8_BIT));
               Index = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("ResetStartupParametersCommand [");
               builder.Append(base.ToString());
               builder.Append(", Option=");
               builder.Append(Option);
               builder.Append(", Index=");
               builder.Append(Index);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
