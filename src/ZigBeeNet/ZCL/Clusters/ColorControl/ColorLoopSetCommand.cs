﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.ColorControl;

/**
 * Color Loop Set Command value object class.
 *
 * Cluster: Color Control. Command is sentTO the server.
 * This command is a specific command used for the Color Control cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.ColorControl
{
       public class ColorLoopSetCommand : ZclCommand
       {
           /**
           * Update Flags command message field.
           */
           public byte UpdateFlags { get; set; }

           /**
           * Action command message field.
           */
           public byte Action { get; set; }

           /**
           * Direction command message field.
           */
           public byte Direction { get; set; }

           /**
           * Transition time command message field.
           */
           public ushort TransitionTime { get; set; }

           /**
           * Start Hue command message field.
           */
           public ushort StartHue { get; set; }


           /**
           * Default constructor.
           */
           public ColorLoopSetCommand()
           {
               GenericCommand = false;
               ClusterId = 768;
               CommandId = 67;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(UpdateFlags, ZclDataType.Get(DataType.BITMAP_8_BIT));
            serializer.Serialize(Action, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(Direction, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(TransitionTime, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(StartHue, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               UpdateFlags = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.BITMAP_8_BIT));
               Action = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               Direction = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               TransitionTime = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               StartHue = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("ColorLoopSetCommand [");
               builder.Append(base.ToString());
               builder.Append(", UpdateFlags=");
               builder.Append(UpdateFlags);
               builder.Append(", Action=");
               builder.Append(Action);
               builder.Append(", Direction=");
               builder.Append(Direction);
               builder.Append(", TransitionTime=");
               builder.Append(TransitionTime);
               builder.Append(", StartHue=");
               builder.Append(StartHue);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
