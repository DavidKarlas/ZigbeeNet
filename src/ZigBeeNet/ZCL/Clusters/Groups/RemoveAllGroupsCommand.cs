﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Groups;

/**
 * Remove All Groups Command value object class.
 *
 * Cluster: Groups. Command is sentTO the server.
 * This command is a specific command used for the Groups cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Groups
{
       public class RemoveAllGroupsCommand : ZclCommand
       {

           /**
           * Default constructor.
           */
           public RemoveAllGroupsCommand()
           {
               GenericCommand = false;
               ClusterId = 4;
               CommandId = 4;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("RemoveAllGroupsCommand [");
               builder.Append(base.ToString());
               builder.Append(']');

               return builder.ToString();
           }

       }
}
