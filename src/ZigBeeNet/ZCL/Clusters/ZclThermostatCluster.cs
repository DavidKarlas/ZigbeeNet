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
using ZigBeeNet.ZCL.Clusters.Thermostat;

/**
 * Thermostatcluster implementation (Cluster ID 0x0201).
 *
 * Code is auto-generated. Modifications may be overwritten!
 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclThermostatCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0201;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Thermostat";

       /* Attribute constants */
       /**
        * LocalTemperature represents the temperature in degrees Celsius, as measured locally.       */
       public static ushort ATTR_LOCALTEMPERATURE = 0x0000;

       /**
        * OutdoorTemperature represents the temperature in degrees Celsius, as measured locally.       */
       public static ushort ATTR_OUTDOORTEMPERATURE = 0x0001;

       /**
        * Occupancy specifies whether the heated/cooled space is occupied or not       */
       public static ushort ATTR_OCCUPANCY = 0x0002;

       /**
        * The MinHeatSetpointLimit attribute specifies the absolute minimum level that the heating setpoint MAY be        * set to. This is a limitation imposed by the manufacturer.       */
       public static ushort ATTR_ABSMINHEATSETPOINTLIMIT = 0x0003;

       /**
        * The MaxHeatSetpointLimit attribute specifies the absolute maximum level that the heating setpoint MAY be        * set to. This is a limitation imposed by the manufacturer.       */
       public static ushort ATTR_ABSMAXHEATSETPOINTLIMIT = 0x0004;

       /**
        * The MinCoolSetpointLimit attribute specifies the absolute minimum level that the cooling setpoint MAY be        * set to. This is a limitation imposed by the manufacturer.       */
       public static ushort ATTR_ABSMINCOOLSETPOINTLIMIT = 0x0005;

       /**
        * The MaxCoolSetpointLimit attribute specifies the absolute maximum level that the cooling setpoint MAY be        * set to. This is a limitation imposed by the manufacturer.       */
       public static ushort ATTR_ABSMAXCOOLSETPOINTLIMIT = 0x0006;

       /**
        * The PICoolingDemandattribute is 8 bits in length and specifies the level of cooling demanded by the PI        * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the        * thermostat is in “off” or “heating” mode.       */
       public static ushort ATTR_PICOOLINGDEMAND = 0x0007;

       /**
        * The PIHeatingDemand attribute is 8 bits in length and specifies the level of heating demanded by the PI        * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the        * thermostat is in “off” or “cooling” mode.       */
       public static ushort ATTR_PIHEATINGDEMAND = 0x0008;

       /**
       */
       public static ushort ATTR_HVACSYSTEMTYPECONFIGURATION = 0x0009;

       /**
       */
       public static ushort ATTR_LOCALTEMPERATURECALIBRATION = 0x0010;

       /**
       */
       public static ushort ATTR_OCCUPIEDCOOLINGSETPOINT = 0x0011;

       /**
       */
       public static ushort ATTR_OCCUPIEDHEATINGSETPOINT = 0x0012;

       /**
       */
       public static ushort ATTR_UNOCCUPIEDCOOLINGSETPOINT = 0x0013;

       /**
       */
       public static ushort ATTR_UNOCCUPIEDHEATINGSETPOINT = 0x0014;

       /**
       */
       public static ushort ATTR_MINHEATSETPOINTLIMIT = 0x0015;

       /**
       */
       public static ushort ATTR_MAXHEATSETPOINTLIMIT = 0x0016;

       /**
       */
       public static ushort ATTR_MINCOOLSETPOINTLIMIT = 0x0017;

       /**
       */
       public static ushort ATTR_MAXCOOLSETPOINTLIMIT = 0x0018;

       /**
       */
       public static ushort ATTR_MINSETPOINTDEADBAND = 0x0019;

       /**
       */
       public static ushort ATTR_REMOTESENSING = 0x001A;

       /**
       */
       public static ushort ATTR_CONTROLSEQUENCEOFOPERATION = 0x001B;

       /**
       */
       public static ushort ATTR_SYSTEMMODE = 0x001C;

       /**
       */
       public static ushort ATTR_ALARMMASK = 0x001D;

       /**
       */
       public static ushort ATTR_THERMOSTATRUNNINGMODE = 0x001E;

       /**
        * This indicates the type of errors encountered within the Mini Split AC. Error values are reported with four bytes        * values. Each bit within the four bytes indicates the unique error.       */
       public static ushort ATTR_ACERRORCODE = 0x0044;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(26);

           ZclClusterType thermostat = ZclClusterType.GetValueById(ClusterType.THERMOSTAT);

           attributeMap.Add(ATTR_LOCALTEMPERATURE, new ZclAttribute(thermostat, ATTR_LOCALTEMPERATURE, "LocalTemperature", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, true));
           attributeMap.Add(ATTR_OUTDOORTEMPERATURE, new ZclAttribute(thermostat, ATTR_OUTDOORTEMPERATURE, "OutdoorTemperature", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_OCCUPANCY, new ZclAttribute(thermostat, ATTR_OCCUPANCY, "Occupancy", ZclDataType.Get(DataType.BITMAP_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_ABSMINHEATSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_ABSMINHEATSETPOINTLIMIT, "AbsMinHeatSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_ABSMAXHEATSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_ABSMAXHEATSETPOINTLIMIT, "AbsMaxHeatSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_ABSMINCOOLSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_ABSMINCOOLSETPOINTLIMIT, "AbsMinCoolSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_ABSMAXCOOLSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_ABSMAXCOOLSETPOINTLIMIT, "AbsMaxCoolSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_PICOOLINGDEMAND, new ZclAttribute(thermostat, ATTR_PICOOLINGDEMAND, "PICoolingDemand", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, true));
           attributeMap.Add(ATTR_PIHEATINGDEMAND, new ZclAttribute(thermostat, ATTR_PIHEATINGDEMAND, "PIHeatingDemand", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, true));
           attributeMap.Add(ATTR_HVACSYSTEMTYPECONFIGURATION, new ZclAttribute(thermostat, ATTR_HVACSYSTEMTYPECONFIGURATION, "HVACSystemTypeConfiguration", ZclDataType.Get(DataType.BITMAP_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_LOCALTEMPERATURECALIBRATION, new ZclAttribute(thermostat, ATTR_LOCALTEMPERATURECALIBRATION, "LocalTemperatureCalibration", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_OCCUPIEDCOOLINGSETPOINT, new ZclAttribute(thermostat, ATTR_OCCUPIEDCOOLINGSETPOINT, "OccupiedCoolingSetpoint", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_OCCUPIEDHEATINGSETPOINT, new ZclAttribute(thermostat, ATTR_OCCUPIEDHEATINGSETPOINT, "OccupiedHeatingSetpoint", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_UNOCCUPIEDCOOLINGSETPOINT, new ZclAttribute(thermostat, ATTR_UNOCCUPIEDCOOLINGSETPOINT, "UnoccupiedCoolingSetpoint", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_UNOCCUPIEDHEATINGSETPOINT, new ZclAttribute(thermostat, ATTR_UNOCCUPIEDHEATINGSETPOINT, "UnoccupiedHeatingSetpoint", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_MINHEATSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_MINHEATSETPOINTLIMIT, "MinHeatSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_MAXHEATSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_MAXHEATSETPOINTLIMIT, "MaxHeatSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_MINCOOLSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_MINCOOLSETPOINTLIMIT, "MinCoolSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_MAXCOOLSETPOINTLIMIT, new ZclAttribute(thermostat, ATTR_MAXCOOLSETPOINTLIMIT, "MaxCoolSetpointLimit", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_MINSETPOINTDEADBAND, new ZclAttribute(thermostat, ATTR_MINSETPOINTDEADBAND, "MinSetpointDeadBand", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_REMOTESENSING, new ZclAttribute(thermostat, ATTR_REMOTESENSING, "RemoteSensing", ZclDataType.Get(DataType.BITMAP_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_CONTROLSEQUENCEOFOPERATION, new ZclAttribute(thermostat, ATTR_CONTROLSEQUENCEOFOPERATION, "ControlSequenceOfOperation", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, false, false));
           attributeMap.Add(ATTR_SYSTEMMODE, new ZclAttribute(thermostat, ATTR_SYSTEMMODE, "SystemMode", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, false, false));
           attributeMap.Add(ATTR_ALARMMASK, new ZclAttribute(thermostat, ATTR_ALARMMASK, "AlarmMask", ZclDataType.Get(DataType.ENUMERATION_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_THERMOSTATRUNNINGMODE, new ZclAttribute(thermostat, ATTR_THERMOSTATRUNNINGMODE, "ThermostatRunningMode", ZclDataType.Get(DataType.ENUMERATION_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_ACERRORCODE, new ZclAttribute(thermostat, ATTR_ACERRORCODE, "ACErrorCode", ZclDataType.Get(DataType.BITMAP_32_BIT), false, true, false, false));

           return attributeMap;
       }

       /**
       * Default constructor to create a Thermostat cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclThermostatCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }


       /**
       * Get the LocalTemperature attribute [attribute ID0].
       *
       * LocalTemperature represents the temperature in degrees Celsius, as measured locally.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetLocalTemperatureAsync()
       {
           return Read(_attributes[ATTR_LOCALTEMPERATURE]);
       }

       /**
       * Synchronously Get the LocalTemperature attribute [attribute ID0].
       *
       * LocalTemperature represents the temperature in degrees Celsius, as measured locally.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetLocalTemperature(long refreshPeriod)
       {
           if (_attributes[ATTR_LOCALTEMPERATURE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_LOCALTEMPERATURE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_LOCALTEMPERATURE]);
       }


       /**
       * Set reporting for the LocalTemperature attribute [attribute ID0].
       *
       * LocalTemperature represents the temperature in degrees Celsius, as measured locally.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetLocalTemperatureReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_LOCALTEMPERATURE], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the OutdoorTemperature attribute [attribute ID1].
       *
       * OutdoorTemperature represents the temperature in degrees Celsius, as measured locally.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetOutdoorTemperatureAsync()
       {
           return Read(_attributes[ATTR_OUTDOORTEMPERATURE]);
       }

       /**
       * Synchronously Get the OutdoorTemperature attribute [attribute ID1].
       *
       * OutdoorTemperature represents the temperature in degrees Celsius, as measured locally.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetOutdoorTemperature(long refreshPeriod)
       {
           if (_attributes[ATTR_OUTDOORTEMPERATURE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_OUTDOORTEMPERATURE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_OUTDOORTEMPERATURE]);
       }


       /**
       * Get the Occupancy attribute [attribute ID2].
       *
       * Occupancy specifies whether the heated/cooled space is occupied or not       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetOccupancyAsync()
       {
           return Read(_attributes[ATTR_OCCUPANCY]);
       }

       /**
       * Synchronously Get the Occupancy attribute [attribute ID2].
       *
       * Occupancy specifies whether the heated/cooled space is occupied or not       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetOccupancy(long refreshPeriod)
       {
           if (_attributes[ATTR_OCCUPANCY].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_OCCUPANCY].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_OCCUPANCY]);
       }


       /**
       * Get the AbsMinHeatSetpointLimit attribute [attribute ID3].
       *
       * The MinHeatSetpointLimit attribute specifies the absolute minimum level that the heating setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetAbsMinHeatSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_ABSMINHEATSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the AbsMinHeatSetpointLimit attribute [attribute ID3].
       *
       * The MinHeatSetpointLimit attribute specifies the absolute minimum level that the heating setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetAbsMinHeatSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_ABSMINHEATSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ABSMINHEATSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ABSMINHEATSETPOINTLIMIT]);
       }


       /**
       * Get the AbsMaxHeatSetpointLimit attribute [attribute ID4].
       *
       * The MaxHeatSetpointLimit attribute specifies the absolute maximum level that the heating setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetAbsMaxHeatSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_ABSMAXHEATSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the AbsMaxHeatSetpointLimit attribute [attribute ID4].
       *
       * The MaxHeatSetpointLimit attribute specifies the absolute maximum level that the heating setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetAbsMaxHeatSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_ABSMAXHEATSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ABSMAXHEATSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ABSMAXHEATSETPOINTLIMIT]);
       }


       /**
       * Get the AbsMinCoolSetpointLimit attribute [attribute ID5].
       *
       * The MinCoolSetpointLimit attribute specifies the absolute minimum level that the cooling setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetAbsMinCoolSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_ABSMINCOOLSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the AbsMinCoolSetpointLimit attribute [attribute ID5].
       *
       * The MinCoolSetpointLimit attribute specifies the absolute minimum level that the cooling setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetAbsMinCoolSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_ABSMINCOOLSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ABSMINCOOLSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ABSMINCOOLSETPOINTLIMIT]);
       }


       /**
       * Get the AbsMaxCoolSetpointLimit attribute [attribute ID6].
       *
       * The MaxCoolSetpointLimit attribute specifies the absolute maximum level that the cooling setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetAbsMaxCoolSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_ABSMAXCOOLSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the AbsMaxCoolSetpointLimit attribute [attribute ID6].
       *
       * The MaxCoolSetpointLimit attribute specifies the absolute maximum level that the cooling setpoint MAY be       * set to. This is a limitation imposed by the manufacturer.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetAbsMaxCoolSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_ABSMAXCOOLSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ABSMAXCOOLSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ABSMAXCOOLSETPOINTLIMIT]);
       }


       /**
       * Get the PICoolingDemand attribute [attribute ID7].
       *
       * The PICoolingDemandattribute is 8 bits in length and specifies the level of cooling demanded by the PI       * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the       * thermostat is in “off” or “heating” mode.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetPICoolingDemandAsync()
       {
           return Read(_attributes[ATTR_PICOOLINGDEMAND]);
       }

       /**
       * Synchronously Get the PICoolingDemand attribute [attribute ID7].
       *
       * The PICoolingDemandattribute is 8 bits in length and specifies the level of cooling demanded by the PI       * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the       * thermostat is in “off” or “heating” mode.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetPICoolingDemand(long refreshPeriod)
       {
           if (_attributes[ATTR_PICOOLINGDEMAND].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_PICOOLINGDEMAND].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_PICOOLINGDEMAND]);
       }


       /**
       * Set reporting for the PICoolingDemand attribute [attribute ID7].
       *
       * The PICoolingDemandattribute is 8 bits in length and specifies the level of cooling demanded by the PI       * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the       * thermostat is in “off” or “heating” mode.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetPICoolingDemandReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_PICOOLINGDEMAND], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the PIHeatingDemand attribute [attribute ID8].
       *
       * The PIHeatingDemand attribute is 8 bits in length and specifies the level of heating demanded by the PI       * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the       * thermostat is in “off” or “cooling” mode.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetPIHeatingDemandAsync()
       {
           return Read(_attributes[ATTR_PIHEATINGDEMAND]);
       }

       /**
       * Synchronously Get the PIHeatingDemand attribute [attribute ID8].
       *
       * The PIHeatingDemand attribute is 8 bits in length and specifies the level of heating demanded by the PI       * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the       * thermostat is in “off” or “cooling” mode.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetPIHeatingDemand(long refreshPeriod)
       {
           if (_attributes[ATTR_PIHEATINGDEMAND].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_PIHEATINGDEMAND].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_PIHEATINGDEMAND]);
       }


       /**
       * Set reporting for the PIHeatingDemand attribute [attribute ID8].
       *
       * The PIHeatingDemand attribute is 8 bits in length and specifies the level of heating demanded by the PI       * (proportional  integral) control loop in use by the thermostat (if any), in percent.  This value is 0 when the       * thermostat is in “off” or “cooling” mode.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetPIHeatingDemandReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_PIHEATINGDEMAND], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the HVACSystemTypeConfiguration attribute [attribute ID9].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetHVACSystemTypeConfigurationAsync()
       {
           return Read(_attributes[ATTR_HVACSYSTEMTYPECONFIGURATION]);
       }

       /**
       * Synchronously Get the HVACSystemTypeConfiguration attribute [attribute ID9].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetHVACSystemTypeConfiguration(long refreshPeriod)
       {
           if (_attributes[ATTR_HVACSYSTEMTYPECONFIGURATION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_HVACSYSTEMTYPECONFIGURATION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_HVACSYSTEMTYPECONFIGURATION]);
       }


       /**
       * Get the LocalTemperatureCalibration attribute [attribute ID16].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetLocalTemperatureCalibrationAsync()
       {
           return Read(_attributes[ATTR_LOCALTEMPERATURECALIBRATION]);
       }

       /**
       * Synchronously Get the LocalTemperatureCalibration attribute [attribute ID16].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetLocalTemperatureCalibration(long refreshPeriod)
       {
           if (_attributes[ATTR_LOCALTEMPERATURECALIBRATION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_LOCALTEMPERATURECALIBRATION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_LOCALTEMPERATURECALIBRATION]);
       }


       /**
       * Get the OccupiedCoolingSetpoint attribute [attribute ID17].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetOccupiedCoolingSetpointAsync()
       {
           return Read(_attributes[ATTR_OCCUPIEDCOOLINGSETPOINT]);
       }

       /**
       * Synchronously Get the OccupiedCoolingSetpoint attribute [attribute ID17].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetOccupiedCoolingSetpoint(long refreshPeriod)
       {
           if (_attributes[ATTR_OCCUPIEDCOOLINGSETPOINT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_OCCUPIEDCOOLINGSETPOINT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_OCCUPIEDCOOLINGSETPOINT]);
       }


       /**
       * Get the OccupiedHeatingSetpoint attribute [attribute ID18].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetOccupiedHeatingSetpointAsync()
       {
           return Read(_attributes[ATTR_OCCUPIEDHEATINGSETPOINT]);
       }

       /**
       * Synchronously Get the OccupiedHeatingSetpoint attribute [attribute ID18].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetOccupiedHeatingSetpoint(long refreshPeriod)
       {
           if (_attributes[ATTR_OCCUPIEDHEATINGSETPOINT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_OCCUPIEDHEATINGSETPOINT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_OCCUPIEDHEATINGSETPOINT]);
       }


       /**
       * Get the UnoccupiedCoolingSetpoint attribute [attribute ID19].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetUnoccupiedCoolingSetpointAsync()
       {
           return Read(_attributes[ATTR_UNOCCUPIEDCOOLINGSETPOINT]);
       }

       /**
       * Synchronously Get the UnoccupiedCoolingSetpoint attribute [attribute ID19].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetUnoccupiedCoolingSetpoint(long refreshPeriod)
       {
           if (_attributes[ATTR_UNOCCUPIEDCOOLINGSETPOINT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_UNOCCUPIEDCOOLINGSETPOINT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_UNOCCUPIEDCOOLINGSETPOINT]);
       }


       /**
       * Get the UnoccupiedHeatingSetpoint attribute [attribute ID20].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetUnoccupiedHeatingSetpointAsync()
       {
           return Read(_attributes[ATTR_UNOCCUPIEDHEATINGSETPOINT]);
       }

       /**
       * Synchronously Get the UnoccupiedHeatingSetpoint attribute [attribute ID20].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetUnoccupiedHeatingSetpoint(long refreshPeriod)
       {
           if (_attributes[ATTR_UNOCCUPIEDHEATINGSETPOINT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_UNOCCUPIEDHEATINGSETPOINT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_UNOCCUPIEDHEATINGSETPOINT]);
       }


       /**
       * Get the MinHeatSetpointLimit attribute [attribute ID21].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetMinHeatSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_MINHEATSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the MinHeatSetpointLimit attribute [attribute ID21].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetMinHeatSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_MINHEATSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MINHEATSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MINHEATSETPOINTLIMIT]);
       }


       /**
       * Get the MaxHeatSetpointLimit attribute [attribute ID22].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetMaxHeatSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_MAXHEATSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the MaxHeatSetpointLimit attribute [attribute ID22].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetMaxHeatSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_MAXHEATSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MAXHEATSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MAXHEATSETPOINTLIMIT]);
       }


       /**
       * Get the MinCoolSetpointLimit attribute [attribute ID23].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetMinCoolSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_MINCOOLSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the MinCoolSetpointLimit attribute [attribute ID23].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetMinCoolSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_MINCOOLSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MINCOOLSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MINCOOLSETPOINTLIMIT]);
       }


       /**
       * Get the MaxCoolSetpointLimit attribute [attribute ID24].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetMaxCoolSetpointLimitAsync()
       {
           return Read(_attributes[ATTR_MAXCOOLSETPOINTLIMIT]);
       }

       /**
       * Synchronously Get the MaxCoolSetpointLimit attribute [attribute ID24].
       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetMaxCoolSetpointLimit(long refreshPeriod)
       {
           if (_attributes[ATTR_MAXCOOLSETPOINTLIMIT].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MAXCOOLSETPOINTLIMIT].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MAXCOOLSETPOINTLIMIT]);
       }


       /**
       * Get the MinSetpointDeadBand attribute [attribute ID25].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetMinSetpointDeadBandAsync()
       {
           return Read(_attributes[ATTR_MINSETPOINTDEADBAND]);
       }

       /**
       * Synchronously Get the MinSetpointDeadBand attribute [attribute ID25].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetMinSetpointDeadBand(long refreshPeriod)
       {
           if (_attributes[ATTR_MINSETPOINTDEADBAND].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_MINSETPOINTDEADBAND].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_MINSETPOINTDEADBAND]);
       }


       /**
       * Get the RemoteSensing attribute [attribute ID26].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetRemoteSensingAsync()
       {
           return Read(_attributes[ATTR_REMOTESENSING]);
       }

       /**
       * Synchronously Get the RemoteSensing attribute [attribute ID26].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetRemoteSensing(long refreshPeriod)
       {
           if (_attributes[ATTR_REMOTESENSING].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_REMOTESENSING].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_REMOTESENSING]);
       }


       /**
       * Get the ControlSequenceOfOperation attribute [attribute ID27].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetControlSequenceOfOperationAsync()
       {
           return Read(_attributes[ATTR_CONTROLSEQUENCEOFOPERATION]);
       }

       /**
       * Synchronously Get the ControlSequenceOfOperation attribute [attribute ID27].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetControlSequenceOfOperation(long refreshPeriod)
       {
           if (_attributes[ATTR_CONTROLSEQUENCEOFOPERATION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_CONTROLSEQUENCEOFOPERATION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_CONTROLSEQUENCEOFOPERATION]);
       }


       /**
       * Get the SystemMode attribute [attribute ID28].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetSystemModeAsync()
       {
           return Read(_attributes[ATTR_SYSTEMMODE]);
       }

       /**
       * Synchronously Get the SystemMode attribute [attribute ID28].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetSystemMode(long refreshPeriod)
       {
           if (_attributes[ATTR_SYSTEMMODE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_SYSTEMMODE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_SYSTEMMODE]);
       }


       /**
       * Get the AlarmMask attribute [attribute ID29].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetAlarmMaskAsync()
       {
           return Read(_attributes[ATTR_ALARMMASK]);
       }

       /**
       * Synchronously Get the AlarmMask attribute [attribute ID29].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetAlarmMask(long refreshPeriod)
       {
           if (_attributes[ATTR_ALARMMASK].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ALARMMASK].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ALARMMASK]);
       }


       /**
       * Get the ThermostatRunningMode attribute [attribute ID30].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetThermostatRunningModeAsync()
       {
           return Read(_attributes[ATTR_THERMOSTATRUNNINGMODE]);
       }

       /**
       * Synchronously Get the ThermostatRunningMode attribute [attribute ID30].
       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetThermostatRunningMode(long refreshPeriod)
       {
           if (_attributes[ATTR_THERMOSTATRUNNINGMODE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_THERMOSTATRUNNINGMODE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_THERMOSTATRUNNINGMODE]);
       }


       /**
       * Get the ACErrorCode attribute [attribute ID68].
       *
       * This indicates the type of errors encountered within the Mini Split AC. Error values are reported with four bytes       * values. Each bit within the four bytes indicates the unique error.       *
       * The attribute is of type int.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetACErrorCodeAsync()
       {
           return Read(_attributes[ATTR_ACERRORCODE]);
       }

       /**
       * Synchronously Get the ACErrorCode attribute [attribute ID68].
       *
       * This indicates the type of errors encountered within the Mini Split AC. Error values are reported with four bytes       * values. Each bit within the four bytes indicates the unique error.       *
       * The attribute is of type int.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public int GetACErrorCode(long refreshPeriod)
       {
           if (_attributes[ATTR_ACERRORCODE].IsLastValueCurrent(refreshPeriod))
           {
               return (int)_attributes[ATTR_ACERRORCODE].LastValue;
           }

           return (int)ReadSync(_attributes[ATTR_ACERRORCODE]);
       }


       /**
       * The Setpoint Raise/Lower Command
       *
       * @param mode {@link byte} Mode
       * @param amount {@link sbyte} Amount
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetpointRaiseLowerCommand(byte mode, sbyte amount)
       {
           SetpointRaiseLowerCommand command = new SetpointRaiseLowerCommand();

           // Set the fields
           command.Mode = mode;
           command.Amount = amount;

           return Send(command);
       }

       /**
       * The Set Weekly Schedule
       *
       * The set weekly schedule command is used to update the thermostat weekly set point schedule from a management system.       * If the thermostat already has a weekly set point schedule programmed then it SHOULD replace each daily set point set       * as it receives the updates from the management system. For example if the thermostat has 4 set points for every day of       * the week and is sent a Set Weekly Schedule command with one set point for Saturday then the thermostat SHOULD remove       * all 4 set points for Saturday and replace those with the updated set point but leave all other days unchanged.       * <br>       * If the schedule is larger than what fits in one ZigBee frame or contains more than 10 transitions, the schedule SHALL       * then be sent using multipleSet Weekly Schedule Commands.       *
       * @param numberOfTransitions {@link byte} Number of Transitions
       * @param dayOfWeek {@link byte} Day of Week
       * @param mode {@link byte} Mode
       * @param transition {@link ushort} Transition
       * @param heatSet {@link ushort} Heat Set
       * @param coolSet {@link ushort} Cool Set
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetWeeklySchedule(byte numberOfTransitions, byte dayOfWeek, byte mode, ushort transition, ushort heatSet, ushort coolSet)
       {
           SetWeeklySchedule command = new SetWeeklySchedule();

           // Set the fields
           command.NumberOfTransitions = numberOfTransitions;
           command.DayOfWeek = dayOfWeek;
           command.Mode = mode;
           command.Transition = transition;
           command.HeatSet = heatSet;
           command.CoolSet = coolSet;

           return Send(command);
       }

       /**
       * The Get Weekly Schedule
       *
       * @param daysToReturn {@link byte} Days To Return
       * @param modeToReturn {@link byte} Mode To Return
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetWeeklySchedule(byte daysToReturn, byte modeToReturn)
       {
           GetWeeklySchedule command = new GetWeeklySchedule();

           // Set the fields
           command.DaysToReturn = daysToReturn;
           command.ModeToReturn = modeToReturn;

           return Send(command);
       }

       /**
       * The Clear Weekly Schedule
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> ClearWeeklySchedule()
       {
           ClearWeeklySchedule command = new ClearWeeklySchedule();

           return Send(command);
       }

       /**
       * The Get Relay Status Log
       *
       * The Get Relay Status Log command is used to query the thermostat internal relay status log. This command has no payload.       * <br>       * The log storing order is First in First Out (FIFO) when the log is generated and stored into the Queue.       * <br>       * The first record in the log (i.e., the oldest) one, is the first to be replaced when there is a new record and there is       * no more space in the log. Thus, the newest record will overwrite the oldest one if there is no space left.       * <br>       * The log storing order is Last In First Out (LIFO) when the log is being retrieved from the Queue by a client device.       * Once the "Get Relay Status Log Response" frame is sent by the Server, the "Unread Entries" attribute       * SHOULD be decremented to indicate the number of unread records that remain in the queue.       * <br>       * If the "Unread Entries"attribute reaches zero and the Client sends a new "Get Relay Status Log Request", the Server       * MAY send one of the following items as a response:       * <br>       * i) resend the last Get Relay Status Log Response       * or       * ii) generate new log record at the time of request and send Get Relay Status Log Response with the new data       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetRelayStatusLog()
       {
           GetRelayStatusLog command = new GetRelayStatusLog();

           return Send(command);
       }

       /**
       * The Get Weekly Schedule Response
       *
       * @param numberOfTransitions {@link byte} Number of Transitions
       * @param dayOfWeek {@link byte} Day of Week
       * @param mode {@link byte} Mode
       * @param transition {@link ushort} Transition
       * @param heatSet {@link ushort} Heat Set
       * @param coolSet {@link ushort} Cool Set
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetWeeklyScheduleResponse(byte numberOfTransitions, byte dayOfWeek, byte mode, ushort transition, ushort heatSet, ushort coolSet)
       {
           GetWeeklyScheduleResponse command = new GetWeeklyScheduleResponse();

           // Set the fields
           command.NumberOfTransitions = numberOfTransitions;
           command.DayOfWeek = dayOfWeek;
           command.Mode = mode;
           command.Transition = transition;
           command.HeatSet = heatSet;
           command.CoolSet = coolSet;

           return Send(command);
       }

       /**
       * The Get Relay Status Log Response
       *
       * @param timeOfDay {@link ushort} Time of day
       * @param relayStatus {@link byte} Relay Status
       * @param localTemperature {@link ushort} Local Temperature
       * @param humidity {@link byte} Humidity
       * @param setpoint {@link ushort} Setpoint
       * @param unreadEntries {@link ushort} Unread Entries
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetRelayStatusLogResponse(ushort timeOfDay, byte relayStatus, ushort localTemperature, byte humidity, ushort setpoint, ushort unreadEntries)
       {
           GetRelayStatusLogResponse command = new GetRelayStatusLogResponse();

           // Set the fields
           command.TimeOfDay = timeOfDay;
           command.RelayStatus = relayStatus;
           command.LocalTemperature = localTemperature;
           command.Humidity = humidity;
           command.Setpoint = setpoint;
           command.UnreadEntries = unreadEntries;

           return Send(command);
       }

       public override ZclCommand GetCommandFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // SETPOINT_RAISE_LOWER_COMMAND
                   return new SetpointRaiseLowerCommand();
               case 1: // SET_WEEKLY_SCHEDULE
                   return new SetWeeklySchedule();
               case 2: // GET_WEEKLY_SCHEDULE
                   return new GetWeeklySchedule();
               case 3: // CLEAR_WEEKLY_SCHEDULE
                   return new ClearWeeklySchedule();
               case 4: // GET_RELAY_STATUS_LOG
                   return new GetRelayStatusLog();
                   default:
                       return null;
           }
       }

       public ZclCommand getResponseFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // GET_WEEKLY_SCHEDULE_RESPONSE
                   return new GetWeeklyScheduleResponse();
               case 1: // GET_RELAY_STATUS_LOG_RESPONSE
                   return new GetRelayStatusLogResponse();
                   default:
                       return null;
           }
       }
   }
}
