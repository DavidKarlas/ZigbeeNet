﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.ColorControl;

/**
 * Step Saturation Command value object class.
 *
 * Cluster: Color Control. Command is sentTO the server.
 * This command is a specific command used for the Color Control cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.ColorControl
{
       public class StepSaturationCommand : ZclCommand
       {
           /**
           * Step mode command message field.
           */
           public byte StepMode { get; set; }

           /**
           * Step size command message field.
           */
           public byte StepSize { get; set; }

           /**
           * Transition time command message field.
           */
           public byte TransitionTime { get; set; }


           /**
           * Default constructor.
           */
           public StepSaturationCommand()
           {
               GenericCommand = false;
               ClusterId = 768;
               CommandId = 5;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(StepMode, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(StepSize, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(TransitionTime, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               StepMode = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               StepSize = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
               TransitionTime = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("StepSaturationCommand [");
               builder.Append(base.ToString());
               builder.Append(", StepMode=");
               builder.Append(StepMode);
               builder.Append(", StepSize=");
               builder.Append(StepSize);
               builder.Append(", TransitionTime=");
               builder.Append(TransitionTime);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
