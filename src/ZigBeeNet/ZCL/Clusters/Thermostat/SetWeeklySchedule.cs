﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Thermostat;

/**
 * Set Weekly Schedule value object class.
 *
 * Cluster: Thermostat. Command is sentTO the server.
 * This command is a specific command used for the Thermostat cluster.
 *
 * The set weekly schedule command is used to update the thermostat weekly set point schedule from a management system. * If the thermostat already has a weekly set point schedule programmed then it SHOULD replace each daily set point set * as it receives the updates from the management system. For example if the thermostat has 4 set points for every day of * the week and is sent a Set Weekly Schedule command with one set point for Saturday then the thermostat SHOULD remove * all 4 set points for Saturday and replace those with the updated set point but leave all other days unchanged. * <br> * If the schedule is larger than what fits in one ZigBee frame or contains more than 10 transitions, the schedule SHALL * then be sent using multipleSet Weekly Schedule Commands. *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Thermostat
{
       public class SetWeeklySchedule : ZclCommand
       {
           /**
           * Number of Transitions command message field.
           */
           public byte NumberOfTransitions { get; set; }

           /**
           * Day of Week command message field.
           */
           public byte DayOfWeek { get; set; }

           /**
           * Mode command message field.
           */
           public byte Mode { get; set; }

           /**
           * Transition command message field.
           */
           public ushort Transition { get; set; }

           /**
           * Heat Set command message field.
           */
           public ushort HeatSet { get; set; }

           /**
           * Cool Set command message field.
           */
           public ushort CoolSet { get; set; }


           /**
           * Default constructor.
           */
           public SetWeeklySchedule()
           {
               GenericCommand = false;
               ClusterId = 513;
               CommandId = 1;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(NumberOfTransitions, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(DayOfWeek, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(Mode, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(Transition, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(HeatSet, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(CoolSet, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               NumberOfTransitions = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               DayOfWeek = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               Mode = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               Transition = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               HeatSet = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               CoolSet = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("SetWeeklySchedule [");
               builder.Append(base.ToString());
               builder.Append(", NumberOfTransitions=");
               builder.Append(NumberOfTransitions);
               builder.Append(", DayOfWeek=");
               builder.Append(DayOfWeek);
               builder.Append(", Mode=");
               builder.Append(Mode);
               builder.Append(", Transition=");
               builder.Append(Transition);
               builder.Append(", HeatSet=");
               builder.Append(HeatSet);
               builder.Append(", CoolSet=");
               builder.Append(CoolSet);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
