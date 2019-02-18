﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.OnOff;

/**
 * On With Recall Global Scene Command value object class.
 *
 * Cluster: On/Off. Command is sentTO the server.
 * This command is a specific command used for the On/Off cluster.
 *
 * The On With Recall Global Scene command allows the recall of the settings when the device was turned off. *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 18.02.2019 - 16:46 */
namespace ZigBeeNet.ZCL.Clusters.OnOff
{
       public class OnWithRecallGlobalSceneCommand : ZclCommand
       {

           /**
           * Default constructor.
           */
           public OnWithRecallGlobalSceneCommand()
           {
               GenericCommand = false;
               ClusterId = 6;
               CommandId = 65;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("OnWithRecallGlobalSceneCommand [");
               builder.Append(base.ToString());
               builder.Append(']');

               return builder.ToString();
           }

       }
}
