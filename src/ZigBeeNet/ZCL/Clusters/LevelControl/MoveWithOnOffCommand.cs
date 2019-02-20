﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.LevelControl;

/**
 * Move (with On/Off) Command value object class.
 *
 * Cluster: Level Control. Command is sentTO the server.
 * This command is a specific command used for the Level Control cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.LevelControl
{
       public class MoveWithOnOffCommand : ZclCommand
       {
           /**
           * Move mode command message field.
           */
           public byte MoveMode { get; set; }

           /**
           * Rate command message field.
           */
           public byte Rate { get; set; }


           /**
           * Default constructor.
           */
           public MoveWithOnOffCommand()
           {
               GenericCommand = false;
               ClusterId = 8;
               CommandId = 5;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(MoveMode, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(Rate, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               MoveMode = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               Rate = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("MoveWithOnOffCommand [");
               builder.Append(base.ToString());
               builder.Append(", MoveMode=");
               builder.Append(MoveMode);
               builder.Append(", Rate=");
               builder.Append(Rate);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
