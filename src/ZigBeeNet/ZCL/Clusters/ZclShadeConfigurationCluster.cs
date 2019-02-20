﻿// License text here

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZigBeeNet.DAO;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;

/**
 * Shade Configurationcluster implementation (Cluster ID 0x0100).
 *
 * Code is auto-generated. Modifications may be overwritten!
 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclShadeConfigurationCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0100;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Shade Configuration";

       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(0);

           return attributeMap;
       }

       /**
       * Default constructor to create a Shade Configuration cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclShadeConfigurationCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

   }
}
