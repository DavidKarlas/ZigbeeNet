﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Thermostat;

/**
 * Setpoint Raise/Lower Command value object class.
 *
 * Cluster: Thermostat. Command is sentTO the server.
 * This command is a specific command used for the Thermostat cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Thermostat
{
       public class SetpointRaiseLowerCommand : ZclCommand
       {
           /**
           * Mode command message field.
           */
           public byte Mode { get; set; }

           /**
           * Amount command message field.
           */
           public sbyte Amount { get; set; }


           /**
           * Default constructor.
           */
           public SetpointRaiseLowerCommand()
           {
               GenericCommand = false;
               ClusterId = 513;
               CommandId = 0;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Mode, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(Amount, ZclDataType.Get(DataType.SIGNED_8_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Mode = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               Amount = deserializer.Deserialize<sbyte>(ZclDataType.Get(DataType.SIGNED_8_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("SetpointRaiseLowerCommand [");
               builder.Append(base.ToString());
               builder.Append(", Mode=");
               builder.Append(Mode);
               builder.Append(", Amount=");
               builder.Append(Amount);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
