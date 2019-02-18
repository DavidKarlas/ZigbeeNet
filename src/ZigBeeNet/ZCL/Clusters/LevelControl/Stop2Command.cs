﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.LevelControl;

/**
 * Stop 2 Command value object class.
 *
 * Cluster: Level Control. Command is sentTO the server.
 * This command is a specific command used for the Level Control cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 18.02.2019 - 16:46 */
namespace ZigBeeNet.ZCL.Clusters.LevelControl
{
       public class Stop2Command : ZclCommand
       {

           /**
           * Default constructor.
           */
           public Stop2Command()
           {
               GenericCommand = false;
               ClusterId = 8;
               CommandId = 7;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("Stop2Command [");
               builder.Append(base.ToString());
               builder.Append(']');

               return builder.ToString();
           }

       }
}
