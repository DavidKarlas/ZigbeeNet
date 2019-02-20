﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Commissioning;

/**
 * Restore Startup Parameters Response value object class.
 *
 * Cluster: Commissioning. Command is sentFROM the server.
 * This command is a specific command used for the Commissioning cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Commissioning
{
       public class RestoreStartupParametersResponse : ZclCommand
       {
           /**
           * Status command message field.
           */
           public byte Status { get; set; }


           /**
           * Default constructor.
           */
           public RestoreStartupParametersResponse()
           {
               GenericCommand = false;
               ClusterId = 21;
               CommandId = 2;
               CommandDirection = ZclCommandDirection.SERVER_TO_CLIENT;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Status, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Status = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("RestoreStartupParametersResponse [");
               builder.Append(base.ToString());
               builder.Append(", Status=");
               builder.Append(Status);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
