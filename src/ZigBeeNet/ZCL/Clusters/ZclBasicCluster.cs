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
using ZigBeeNet.ZCL.Clusters.Basic;

/**
 *Basiccluster implementation (Cluster ID 0x0000).
 *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 18.02.2019 - 16:46 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclBasicCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0000;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Basic";

       /* Attribute constants */
       /**
        * The ZCLVersion attribute is 8 bits in length and specifies the version number of        * the ZigBee Cluster Library that all clusters on this endpoint conform to.       */
       public static ushort ATTR_ZCLVERSION = 0x0000;

       /**
        * The ApplicationVersion attribute is 8 bits in length and specifies the version        * number of the application software contained in the device. The usage of this        * attribute is manufacturer dependent.       */
       public static ushort ATTR_APPLICATIONVERSION = 0x0001;

       /**
        * The StackVersion attribute is 8 bits in length and specifies the version number        * of the implementation of the ZigBee stack contained in the device. The usage of        * this attribute is manufacturer dependent.       */
       public static ushort ATTR_STACKVERSION = 0x0002;

       /**
        * The HWVersion attribute is 8 bits in length and specifies the version number of        * the hardware of the device. The usage of this attribute is manufacturer dependent.       */
       public static ushort ATTR_HWVERSION = 0x0003;

       /**
        * The ManufacturerName attribute is a maximum of 32 bytes in length and specifies        * the name of the manufacturer as a ZigBee character string.       */
       public static ushort ATTR_MANUFACTURERNAME = 0x0004;

       /**
        * The ModelIdentifier attribute is a maximum of 32 bytes in length and specifies the        * model number (or other identifier) assigned by the manufacturer as a ZigBee character string.       */
       public static ushort ATTR_MODELIDENTIFIER = 0x0005;

       /**
        * The DateCode attribute is a ZigBee character string with a maximum length of 16 bytes.        * The first 8 characters specify the date of manufacturer of the device in international        * date notation according to ISO 8601, i.e. YYYYMMDD, e.g. 20060814.       */
       public static ushort ATTR_DATECODE = 0x0006;

       /**
        * The PowerSource attribute is 8 bits in length and specifies the source(s) of power        * available to the device. Bits b0–b6 of this attribute represent the primary power        * source of the device and bit b7 indicates whether the device has a secondary power        * source in the form of a battery backup.       */
       public static ushort ATTR_POWERSOURCE = 0x0007;

       /**
        * The LocationDescription attribute is a maximum of 16 bytes in length and describes        * the physical location of the device as a ZigBee character string.       */
       public static ushort ATTR_LOCATIONDESCRIPTION = 0x0010;

       /**
        * The PhysicalEnvironment attribute is 8 bits in length and specifies the type of        * physical environment in which the device will operate.       */
       public static ushort ATTR_PHYSICALENVIRONMENT = 0x0011;

       /**
        * The DeviceEnabled attribute is a boolean and specifies whether the device is enabled        * or disabled.       */
       public static ushort ATTR_DEVICEENABLED = 0x0012;

       /**
        * The AlarmMask attribute is 8 bits in length and specifies which of a number of general        * alarms may be generated.       */
       public static ushort ATTR_ALARMMASK = 0x0013;

       /**
        * The DisableLocalConfig attribute allows a number of local device configuration        * functions to be disabled.        * <p>        * The intention of this attribute is to allow disabling of any local configuration        * user interface, for example to prevent reset or binding buttons being activated by        * unauthorised persons in a public building.       */
       public static ushort ATTR_DISABLELOCALCONFIG = 0x0014;

       /**
        * The SWBuildIDattribute represents a detailed, manufacturer-specific reference to the version of the software.       */
       public static ushort ATTR_SWBUILDID = 0x4000;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(14);

           ZclClusterType basic = ZclClusterType.GetValueById(ClusterType.BASIC);

           attributeMap.Add(ATTR_ZCLVERSION, new ZclAttribute(basic, ATTR_ZCLVERSION, "ZCLVersion", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_APPLICATIONVERSION, new ZclAttribute(basic, ATTR_APPLICATIONVERSION, "ApplicationVersion", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_STACKVERSION, new ZclAttribute(basic, ATTR_STACKVERSION, "StackVersion", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_HWVERSION, new ZclAttribute(basic, ATTR_HWVERSION, "HWVersion", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MANUFACTURERNAME, new ZclAttribute(basic, ATTR_MANUFACTURERNAME, "ManufacturerName", ZclDataType.Get(DataType.CHARACTER_STRING), true, true, false, false));
           attributeMap.Add(ATTR_MODELIDENTIFIER, new ZclAttribute(basic, ATTR_MODELIDENTIFIER, "ModelIdentifier", ZclDataType.Get(DataType.CHARACTER_STRING), true, true, false, false));
           attributeMap.Add(ATTR_DATECODE, new ZclAttribute(basic, ATTR_DATECODE, "DateCode", ZclDataType.Get(DataType.CHARACTER_STRING), true, true, false, false));
           attributeMap.Add(ATTR_POWERSOURCE, new ZclAttribute(basic, ATTR_POWERSOURCE, "PowerSource", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, false, false));
           attributeMap.Add(ATTR_LOCATIONDESCRIPTION, new ZclAttribute(basic, ATTR_LOCATIONDESCRIPTION, "LocationDescription", ZclDataType.Get(DataType.CHARACTER_STRING), true, true, true, false));
           attributeMap.Add(ATTR_PHYSICALENVIRONMENT, new ZclAttribute(basic, ATTR_PHYSICALENVIRONMENT, "PhysicalEnvironment", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, true, false));
           attributeMap.Add(ATTR_DEVICEENABLED, new ZclAttribute(basic, ATTR_DEVICEENABLED, "DeviceEnabled", ZclDataType.Get(DataType.BOOLEAN), true, true, true, false));
           attributeMap.Add(ATTR_ALARMMASK, new ZclAttribute(basic, ATTR_ALARMMASK, "AlarmMask", ZclDataType.Get(DataType.BITMAP_8_BIT), true, true, true, false));
           attributeMap.Add(ATTR_DISABLELOCALCONFIG, new ZclAttribute(basic, ATTR_DISABLELOCALCONFIG, "DisableLocalConfig", ZclDataType.Get(DataType.BITMAP_8_BIT), true, true, true, false));
           attributeMap.Add(ATTR_SWBUILDID, new ZclAttribute(basic, ATTR_SWBUILDID, "SWBuildID", ZclDataType.Get(DataType.CHARACTER_STRING), false, true, false, false));

           return attributeMap;
       }

       /**
       * Default constructor to create a Basic cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclBasicCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> GetZCLVersionAsync()
       {
           return Read(_attributes[ATTR_ZCLVERSION]);
       }
       public byte GetZCLVersion(long refreshPeriod)
       {
           if (_attributes[ATTR_ZCLVERSION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ZCLVERSION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ZCLVERSION]);
       }

       public Task<CommandResult> GetApplicationVersionAsync()
       {
           return Read(_attributes[ATTR_APPLICATIONVERSION]);
       }
       public byte GetApplicationVersion(long refreshPeriod)
       {
           if (_attributes[ATTR_APPLICATIONVERSION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_APPLICATIONVERSION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_APPLICATIONVERSION]);
       }

       public Task<CommandResult> GetStackVersionAsync()
       {
           return Read(_attributes[ATTR_STACKVERSION]);
       }
       public byte GetStackVersion(long refreshPeriod)
       {
           if (_attributes[ATTR_STACKVERSION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_STACKVERSION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_STACKVERSION]);
       }

       public Task<CommandResult> GetHWVersionAsync()
       {
           return Read(_attributes[ATTR_HWVERSION]);
       }
       public byte GetHWVersion(long refreshPeriod)
       {
           if (_attributes[ATTR_HWVERSION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_HWVERSION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_HWVERSION]);
       }

       public Task<CommandResult> GetManufacturerNameAsync()
       {
           return Read(_attributes[ATTR_MANUFACTURERNAME]);
       }
       public string GetManufacturerName(long refreshPeriod)
       {
           if (_attributes[ATTR_MANUFACTURERNAME].IsLastValueCurrent(refreshPeriod))
           {
               return (string)_attributes[ATTR_MANUFACTURERNAME].LastValue;
           }

           return (string)ReadSync(_attributes[ATTR_MANUFACTURERNAME]);
       }

       public Task<CommandResult> GetModelIdentifierAsync()
       {
           return Read(_attributes[ATTR_MODELIDENTIFIER]);
       }
       public string GetModelIdentifier(long refreshPeriod)
       {
           if (_attributes[ATTR_MODELIDENTIFIER].IsLastValueCurrent(refreshPeriod))
           {
               return (string)_attributes[ATTR_MODELIDENTIFIER].LastValue;
           }

           return (string)ReadSync(_attributes[ATTR_MODELIDENTIFIER]);
       }

       public Task<CommandResult> GetDateCodeAsync()
       {
           return Read(_attributes[ATTR_DATECODE]);
       }
       public string GetDateCode(long refreshPeriod)
       {
           if (_attributes[ATTR_DATECODE].IsLastValueCurrent(refreshPeriod))
           {
               return (string)_attributes[ATTR_DATECODE].LastValue;
           }

           return (string)ReadSync(_attributes[ATTR_DATECODE]);
       }

       public Task<CommandResult> GetPowerSourceAsync()
       {
           return Read(_attributes[ATTR_POWERSOURCE]);
       }
       public byte GetPowerSource(long refreshPeriod)
       {
           if (_attributes[ATTR_POWERSOURCE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_POWERSOURCE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_POWERSOURCE]);
       }

       public Task<CommandResult> SetLocationDescription(object value)
       {
           return Write(_attributes[ATTR_LOCATIONDESCRIPTION], value);
       }

       public Task<CommandResult> GetLocationDescriptionAsync()
       {
           return Read(_attributes[ATTR_LOCATIONDESCRIPTION]);
       }
       public string GetLocationDescription(long refreshPeriod)
       {
           if (_attributes[ATTR_LOCATIONDESCRIPTION].IsLastValueCurrent(refreshPeriod))
           {
               return (string)_attributes[ATTR_LOCATIONDESCRIPTION].LastValue;
           }

           return (string)ReadSync(_attributes[ATTR_LOCATIONDESCRIPTION]);
       }

       public Task<CommandResult> SetPhysicalEnvironment(object value)
       {
           return Write(_attributes[ATTR_PHYSICALENVIRONMENT], value);
       }

       public Task<CommandResult> GetPhysicalEnvironmentAsync()
       {
           return Read(_attributes[ATTR_PHYSICALENVIRONMENT]);
       }
       public byte GetPhysicalEnvironment(long refreshPeriod)
       {
           if (_attributes[ATTR_PHYSICALENVIRONMENT].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_PHYSICALENVIRONMENT].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_PHYSICALENVIRONMENT]);
       }

       public Task<CommandResult> SetDeviceEnabled(object value)
       {
           return Write(_attributes[ATTR_DEVICEENABLED], value);
       }

       public Task<CommandResult> GetDeviceEnabledAsync()
       {
           return Read(_attributes[ATTR_DEVICEENABLED]);
       }
       public bool GetDeviceEnabled(long refreshPeriod)
       {
           if (_attributes[ATTR_DEVICEENABLED].IsLastValueCurrent(refreshPeriod))
           {
               return (bool)_attributes[ATTR_DEVICEENABLED].LastValue;
           }

           return (bool)ReadSync(_attributes[ATTR_DEVICEENABLED]);
       }

       public Task<CommandResult> SetAlarmMask(object value)
       {
           return Write(_attributes[ATTR_ALARMMASK], value);
       }

       public Task<CommandResult> GetAlarmMaskAsync()
       {
           return Read(_attributes[ATTR_ALARMMASK]);
       }
       public byte GetAlarmMask(long refreshPeriod)
       {
           if (_attributes[ATTR_ALARMMASK].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ALARMMASK].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ALARMMASK]);
       }

       public Task<CommandResult> SetDisableLocalConfig(object value)
       {
           return Write(_attributes[ATTR_DISABLELOCALCONFIG], value);
       }

       public Task<CommandResult> GetDisableLocalConfigAsync()
       {
           return Read(_attributes[ATTR_DISABLELOCALCONFIG]);
       }
       public byte GetDisableLocalConfig(long refreshPeriod)
       {
           if (_attributes[ATTR_DISABLELOCALCONFIG].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_DISABLELOCALCONFIG].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_DISABLELOCALCONFIG]);
       }

       public Task<CommandResult> GetSWBuildIDAsync()
       {
           return Read(_attributes[ATTR_SWBUILDID]);
       }
       public string GetSWBuildID(long refreshPeriod)
       {
           if (_attributes[ATTR_SWBUILDID].IsLastValueCurrent(refreshPeriod))
           {
               return (string)_attributes[ATTR_SWBUILDID].LastValue;
           }

           return (string)ReadSync(_attributes[ATTR_SWBUILDID]);
       }


       /**
       * The Reset to Factory Defaults Command
       *
        * On receipt of this command, the device resets all the attributes of all its clusters        * to their factory defaults. Note that ZigBee networking functionality,bindings, groups        * or other persistent data are not affected by this command       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> ResetToFactoryDefaultsCommand()
       {
           ResetToFactoryDefaultsCommand command = new ResetToFactoryDefaultsCommand();

           return Send(command);
       }

       public override ZclCommand GetCommandFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // RESET_TO_FACTORY_DEFAULTS_COMMAND
                   return new ResetToFactoryDefaultsCommand();
                   default:
                       return null;
           }
       }
   }
}
