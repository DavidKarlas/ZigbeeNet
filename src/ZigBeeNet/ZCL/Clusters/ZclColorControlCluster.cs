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
using ZigBeeNet.ZCL.Clusters.ColorControl;

/**
 * Color Controlcluster implementation (Cluster ID 0x0300).
 *
 * This cluster provides an interface for changing the color of a light. Color is * specified according to the Commission Internationale de l'Éclairage (CIE) * specification CIE 1931 Color Space, [B4]. Color control is carried out in terms of * x,y values, as defined by this specification. *
 * Code is auto-generated. Modifications may be overwritten!
 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclColorControlCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0300;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Color Control";

       /* Attribute constants */
       /**
        * The CurrentHue attribute contains the current hue value of the light. It is updated        * as fast as practical during commands that change the hue.        * <p>        * The hue in degrees shall be related to the CurrentHue attribute by the relationship        * Hue = CurrentHue x 360 / 254 (CurrentHue in the range 0 - 254 inclusive)        * <p>        * If this attribute is implemented then the CurrentSaturation and ColorMode        * attributes shall also be implemented.       */
       public static ushort ATTR_CURRENTHUE = 0x0000;

       /**
        * The CurrentSaturation attribute holds the current saturation value of the light. It is        * updated as fast as practical during commands that change the saturation.        * The saturation shall be related to the CurrentSaturation attribute by the        * relationship        * Saturation = CurrentSaturation/254 (CurrentSaturation in the range 0 - 254 inclusive)        * If this attribute is implemented then the CurrentHue and ColorMode attributes        * shall also be implemented.       */
       public static ushort ATTR_CURRENTSATURATION = 0x0001;

       /**
        * The RemainingTime attribute holds the time remaining, in 1/10ths of a second,        * until the currently active command will be complete.       */
       public static ushort ATTR_REMAININGTIME = 0x0002;

       /**
        * The CurrentX attribute contains the current value of the normalized chromaticity        * value x, as defined in the CIE xyY Color Space. It is updated as fast as practical        * during commands that change the color.        * <p>        * The value of x shall be related to the CurrentX attribute by the relationship        * <p>        * x = CurrentX / 65535 (CurrentX in the range 0 to 65279 inclusive)       */
       public static ushort ATTR_CURRENTX = 0x0003;

       /**
        * The CurrentY attribute contains the current value of the normalized chromaticity        * value y, as defined in the CIE xyY Color Space. It is updated as fast as practical        * during commands that change the color.        * <p>        * The value of y shall be related to the CurrentY attribute by the relationship        * <p>        * y = CurrentY / 65535 (CurrentY in the range 0 to 65279 inclusive)       */
       public static ushort ATTR_CURRENTY = 0x0004;

       /**
        * The DriftCompensation attribute indicates what mechanism, if any, is in use for        * compensation for color/intensity drift over time.       */
       public static ushort ATTR_DRIFTCOMPENSATION = 0x0005;

       /**
        * The CompensationText attribute holds a textual indication of what mechanism, if        * any, is in use to compensate for color/intensity drift over time.       */
       public static ushort ATTR_COMPENSATIONTEXT = 0x0006;

       /**
        * The ColorTemperature attribute contains a scaled inverse of the current value of        * the color temperature. It is updated as fast as practical during commands that        * change the color.        * <p>        * The color temperature value in Kelvins shall be related to the ColorTemperature        * attribute by the relationship        * <p>        * Color temperature = 1,000,000 / ColorTemperature (ColorTemperature in the        * range 1 to 65279 inclusive, giving a color temperature range from 1,000,000        * Kelvins to 15.32 Kelvins).        * <p>        * The value ColorTemperature = 0 indicates an undefined value. The value        * ColorTemperature = 65535 indicates an invalid value.       */
       public static ushort ATTR_COLORTEMPERATURE = 0x0007;

       /**
        * The ColorMode attribute indicates which attributes are currently determining the color of the device.        * If either the CurrentHue or CurrentSaturation attribute is implemented, this attribute SHALL also be        * implemented, otherwise it is optional. The value of the ColorMode attribute cannot be written directly        * - it is set upon reception of another command in to the appropriate mode for that command.       */
       public static ushort ATTR_COLORMODE = 0x0008;

       /**
        * The EnhancedCurrentHueattribute represents non-equidistant steps along the CIE 1931 color        * triangle, and it provides 16-bits precision. The upper 8 bits of this attribute SHALL be        * used as an index in the implementation specific XY lookup table to provide the non-equidistance        * steps (see the ZLL test specification for an example).  The lower 8 bits SHALL be used to        * interpolate between these steps in a linear way in order to provide color zoom for the user.       */
       public static ushort ATTR_ENHANCEDCURRENTHUE = 0x4000;

       /**
        * The EnhancedColorModeattribute specifies which attributes are currently determining the color of the device.        * To provide compatibility with standard ZCL, the original ColorModeattribute SHALLindicate ‘CurrentHueand CurrentSaturation’        * when the light uses the EnhancedCurrentHueattribute.       */
       public static ushort ATTR_ENHANCEDCOLORMODE = 0x4001;

       /**
        * The ColorLoopActive attribute specifies the current active status of the color loop.        * If this attribute has the value 0x00, the color loop SHALLnot be active. If this attribute        * has the value 0x01, the color loop SHALL be active. All other values (0x02 – 0xff) are reserved.       */
       public static ushort ATTR_COLORLOOPACTIVE = 0x4002;

       /**
        * The ColorLoopDirection attribute specifies the current direction of the color loop.        * If this attribute has the value 0x00, the EnhancedCurrentHue attribute SHALL be decremented.        * If this attribute has the value 0x01, the EnhancedCurrentHue attribute SHALL be incremented.        * All other values (0x02 – 0xff) are reserved.       */
       public static ushort ATTR_COLORLOOPDIRECTION = 0x4003;

       /**
        * The ColorLoopTime attribute specifies the number of seconds it SHALL take to perform a full        * color loop, i.e.,to cycle all values of the EnhancedCurrentHue attribute (between 0x0000 and 0xffff).       */
       public static ushort ATTR_COLORLOOPTIME = 0x4004;

       /**
        * The ColorLoopStartEnhancedHueattribute specifies the value of the EnhancedCurrentHue attribute        * from which the color loop SHALL be started.       */
       public static ushort ATTR_COLORLOOPSTARTHUE = 0x4005;

       /**
        * The ColorLoopStoredEnhancedHue attribute specifies the value of the EnhancedCurrentHue attribute        * before the color loop was started. Once the color loop is complete, the EnhancedCurrentHue        * attribute SHALL be restored to this value.       */
       public static ushort ATTR_COLORLOOPSTOREDHUE = 0x4006;

       /**
        * The ColorCapabilitiesattribute specifies the color capabilities of the device supporting the        * color control cluster.        * <p>        * Note:The support of the CurrentXand CurrentYattributes is mandatory regardless of color capabilities.       */
       public static ushort ATTR_COLORCAPABILITIES = 0x400A;

       /**
        * The ColorTempPhysicalMinMiredsattribute indicates the minimum mired value        * supported by the hardware. ColorTempPhysicalMinMiredscorresponds to the maximum        * color temperature in kelvins supported by the hardware.        * ColorTempPhysicalMinMireds ≤ ColorTemperatureMireds       */
       public static ushort ATTR_COLORTEMPERATUREMIN = 0x400B;

       /**
        * The ColorTempPhysicalMaxMiredsattribute indicates the maximum mired value        * supported by the hard-ware. ColorTempPhysicalMaxMiredscorresponds to the minimum        * color temperature in kelvins supported by the hardware.        * ColorTemperatureMireds ≤ ColorTempPhysicalMaxMireds.       */
       public static ushort ATTR_COLORTEMPERATUREMAX = 0x400C;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(19);

           ZclClusterType colorControl = ZclClusterType.GetValueById(ClusterType.COLOR_CONTROL);

           attributeMap.Add(ATTR_CURRENTHUE, new ZclAttribute(colorControl, ATTR_CURRENTHUE, "CurrentHue", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, true));
           attributeMap.Add(ATTR_CURRENTSATURATION, new ZclAttribute(colorControl, ATTR_CURRENTSATURATION, "CurrentSaturation", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, true));
           attributeMap.Add(ATTR_REMAININGTIME, new ZclAttribute(colorControl, ATTR_REMAININGTIME, "RemainingTime", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_CURRENTX, new ZclAttribute(colorControl, ATTR_CURRENTX, "CurrentX", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, true));
           attributeMap.Add(ATTR_CURRENTY, new ZclAttribute(colorControl, ATTR_CURRENTY, "CurrentY", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, true));
           attributeMap.Add(ATTR_DRIFTCOMPENSATION, new ZclAttribute(colorControl, ATTR_DRIFTCOMPENSATION, "DriftCompensation", ZclDataType.Get(DataType.ENUMERATION_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_COMPENSATIONTEXT, new ZclAttribute(colorControl, ATTR_COMPENSATIONTEXT, "CompensationText", ZclDataType.Get(DataType.CHARACTER_STRING), false, true, false, false));
           attributeMap.Add(ATTR_COLORTEMPERATURE, new ZclAttribute(colorControl, ATTR_COLORTEMPERATURE, "ColorTemperature", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, true));
           attributeMap.Add(ATTR_COLORMODE, new ZclAttribute(colorControl, ATTR_COLORMODE, "ColorMode", ZclDataType.Get(DataType.ENUMERATION_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_ENHANCEDCURRENTHUE, new ZclAttribute(colorControl, ATTR_ENHANCEDCURRENTHUE, "EnhancedCurrentHue", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, true));
           attributeMap.Add(ATTR_ENHANCEDCOLORMODE, new ZclAttribute(colorControl, ATTR_ENHANCEDCOLORMODE, "EnhancedColorMode", ZclDataType.Get(DataType.ENUMERATION_8_BIT), false, true, false, false));
           attributeMap.Add(ATTR_COLORLOOPACTIVE, new ZclAttribute(colorControl, ATTR_COLORLOOPACTIVE, "ColorLoopActive", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_COLORLOOPDIRECTION, new ZclAttribute(colorControl, ATTR_COLORLOOPDIRECTION, "ColorLoopDirection", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_COLORLOOPTIME, new ZclAttribute(colorControl, ATTR_COLORLOOPTIME, "ColorLoopTime", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_COLORLOOPSTARTHUE, new ZclAttribute(colorControl, ATTR_COLORLOOPSTARTHUE, "ColorLoopStartHue", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_COLORLOOPSTOREDHUE, new ZclAttribute(colorControl, ATTR_COLORLOOPSTOREDHUE, "ColorLoopStoredHue", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_COLORCAPABILITIES, new ZclAttribute(colorControl, ATTR_COLORCAPABILITIES, "ColorCapabilities", ZclDataType.Get(DataType.BITMAP_16_BIT), false, true, false, false));
           attributeMap.Add(ATTR_COLORTEMPERATUREMIN, new ZclAttribute(colorControl, ATTR_COLORTEMPERATUREMIN, "ColorTemperatureMin", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_COLORTEMPERATUREMAX, new ZclAttribute(colorControl, ATTR_COLORTEMPERATUREMAX, "ColorTemperatureMax", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, false));

           return attributeMap;
       }

       /**
       * Default constructor to create a Color Control cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclColorControlCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }


       /**
       * Get the CurrentHue attribute [attribute ID0].
       *
       * The CurrentHue attribute contains the current hue value of the light. It is updated       * as fast as practical during commands that change the hue.       * <p>       * The hue in degrees shall be related to the CurrentHue attribute by the relationship       * Hue = CurrentHue x 360 / 254 (CurrentHue in the range 0 - 254 inclusive)       * <p>       * If this attribute is implemented then the CurrentSaturation and ColorMode       * attributes shall also be implemented.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetCurrentHueAsync()
       {
           return Read(_attributes[ATTR_CURRENTHUE]);
       }

       /**
       * Synchronously Get the CurrentHue attribute [attribute ID0].
       *
       * The CurrentHue attribute contains the current hue value of the light. It is updated       * as fast as practical during commands that change the hue.       * <p>       * The hue in degrees shall be related to the CurrentHue attribute by the relationship       * Hue = CurrentHue x 360 / 254 (CurrentHue in the range 0 - 254 inclusive)       * <p>       * If this attribute is implemented then the CurrentSaturation and ColorMode       * attributes shall also be implemented.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetCurrentHue(long refreshPeriod)
       {
           if (_attributes[ATTR_CURRENTHUE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_CURRENTHUE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_CURRENTHUE]);
       }


       /**
       * Set reporting for the CurrentHue attribute [attribute ID0].
       *
       * The CurrentHue attribute contains the current hue value of the light. It is updated       * as fast as practical during commands that change the hue.       * <p>       * The hue in degrees shall be related to the CurrentHue attribute by the relationship       * Hue = CurrentHue x 360 / 254 (CurrentHue in the range 0 - 254 inclusive)       * <p>       * If this attribute is implemented then the CurrentSaturation and ColorMode       * attributes shall also be implemented.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetCurrentHueReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_CURRENTHUE], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the CurrentSaturation attribute [attribute ID1].
       *
       * The CurrentSaturation attribute holds the current saturation value of the light. It is       * updated as fast as practical during commands that change the saturation.       * The saturation shall be related to the CurrentSaturation attribute by the       * relationship       * Saturation = CurrentSaturation/254 (CurrentSaturation in the range 0 - 254 inclusive)       * If this attribute is implemented then the CurrentHue and ColorMode attributes       * shall also be implemented.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetCurrentSaturationAsync()
       {
           return Read(_attributes[ATTR_CURRENTSATURATION]);
       }

       /**
       * Synchronously Get the CurrentSaturation attribute [attribute ID1].
       *
       * The CurrentSaturation attribute holds the current saturation value of the light. It is       * updated as fast as practical during commands that change the saturation.       * The saturation shall be related to the CurrentSaturation attribute by the       * relationship       * Saturation = CurrentSaturation/254 (CurrentSaturation in the range 0 - 254 inclusive)       * If this attribute is implemented then the CurrentHue and ColorMode attributes       * shall also be implemented.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetCurrentSaturation(long refreshPeriod)
       {
           if (_attributes[ATTR_CURRENTSATURATION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_CURRENTSATURATION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_CURRENTSATURATION]);
       }


       /**
       * Set reporting for the CurrentSaturation attribute [attribute ID1].
       *
       * The CurrentSaturation attribute holds the current saturation value of the light. It is       * updated as fast as practical during commands that change the saturation.       * The saturation shall be related to the CurrentSaturation attribute by the       * relationship       * Saturation = CurrentSaturation/254 (CurrentSaturation in the range 0 - 254 inclusive)       * If this attribute is implemented then the CurrentHue and ColorMode attributes       * shall also be implemented.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetCurrentSaturationReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_CURRENTSATURATION], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the RemainingTime attribute [attribute ID2].
       *
       * The RemainingTime attribute holds the time remaining, in 1/10ths of a second,       * until the currently active command will be complete.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetRemainingTimeAsync()
       {
           return Read(_attributes[ATTR_REMAININGTIME]);
       }

       /**
       * Synchronously Get the RemainingTime attribute [attribute ID2].
       *
       * The RemainingTime attribute holds the time remaining, in 1/10ths of a second,       * until the currently active command will be complete.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetRemainingTime(long refreshPeriod)
       {
           if (_attributes[ATTR_REMAININGTIME].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_REMAININGTIME].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_REMAININGTIME]);
       }


       /**
       * Get the CurrentX attribute [attribute ID3].
       *
       * The CurrentX attribute contains the current value of the normalized chromaticity       * value x, as defined in the CIE xyY Color Space. It is updated as fast as practical       * during commands that change the color.       * <p>       * The value of x shall be related to the CurrentX attribute by the relationship       * <p>       * x = CurrentX / 65535 (CurrentX in the range 0 to 65279 inclusive)       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetCurrentXAsync()
       {
           return Read(_attributes[ATTR_CURRENTX]);
       }

       /**
       * Synchronously Get the CurrentX attribute [attribute ID3].
       *
       * The CurrentX attribute contains the current value of the normalized chromaticity       * value x, as defined in the CIE xyY Color Space. It is updated as fast as practical       * during commands that change the color.       * <p>       * The value of x shall be related to the CurrentX attribute by the relationship       * <p>       * x = CurrentX / 65535 (CurrentX in the range 0 to 65279 inclusive)       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetCurrentX(long refreshPeriod)
       {
           if (_attributes[ATTR_CURRENTX].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_CURRENTX].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_CURRENTX]);
       }


       /**
       * Set reporting for the CurrentX attribute [attribute ID3].
       *
       * The CurrentX attribute contains the current value of the normalized chromaticity       * value x, as defined in the CIE xyY Color Space. It is updated as fast as practical       * during commands that change the color.       * <p>       * The value of x shall be related to the CurrentX attribute by the relationship       * <p>       * x = CurrentX / 65535 (CurrentX in the range 0 to 65279 inclusive)       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetCurrentXReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_CURRENTX], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the CurrentY attribute [attribute ID4].
       *
       * The CurrentY attribute contains the current value of the normalized chromaticity       * value y, as defined in the CIE xyY Color Space. It is updated as fast as practical       * during commands that change the color.       * <p>       * The value of y shall be related to the CurrentY attribute by the relationship       * <p>       * y = CurrentY / 65535 (CurrentY in the range 0 to 65279 inclusive)       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetCurrentYAsync()
       {
           return Read(_attributes[ATTR_CURRENTY]);
       }

       /**
       * Synchronously Get the CurrentY attribute [attribute ID4].
       *
       * The CurrentY attribute contains the current value of the normalized chromaticity       * value y, as defined in the CIE xyY Color Space. It is updated as fast as practical       * during commands that change the color.       * <p>       * The value of y shall be related to the CurrentY attribute by the relationship       * <p>       * y = CurrentY / 65535 (CurrentY in the range 0 to 65279 inclusive)       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetCurrentY(long refreshPeriod)
       {
           if (_attributes[ATTR_CURRENTY].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_CURRENTY].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_CURRENTY]);
       }


       /**
       * Set reporting for the CurrentY attribute [attribute ID4].
       *
       * The CurrentY attribute contains the current value of the normalized chromaticity       * value y, as defined in the CIE xyY Color Space. It is updated as fast as practical       * during commands that change the color.       * <p>       * The value of y shall be related to the CurrentY attribute by the relationship       * <p>       * y = CurrentY / 65535 (CurrentY in the range 0 to 65279 inclusive)       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is MANDATORY
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetCurrentYReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_CURRENTY], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the DriftCompensation attribute [attribute ID5].
       *
       * The DriftCompensation attribute indicates what mechanism, if any, is in use for       * compensation for color/intensity drift over time.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetDriftCompensationAsync()
       {
           return Read(_attributes[ATTR_DRIFTCOMPENSATION]);
       }

       /**
       * Synchronously Get the DriftCompensation attribute [attribute ID5].
       *
       * The DriftCompensation attribute indicates what mechanism, if any, is in use for       * compensation for color/intensity drift over time.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetDriftCompensation(long refreshPeriod)
       {
           if (_attributes[ATTR_DRIFTCOMPENSATION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_DRIFTCOMPENSATION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_DRIFTCOMPENSATION]);
       }


       /**
       * Get the CompensationText attribute [attribute ID6].
       *
       * The CompensationText attribute holds a textual indication of what mechanism, if       * any, is in use to compensate for color/intensity drift over time.       *
       * The attribute is of type string.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetCompensationTextAsync()
       {
           return Read(_attributes[ATTR_COMPENSATIONTEXT]);
       }

       /**
       * Synchronously Get the CompensationText attribute [attribute ID6].
       *
       * The CompensationText attribute holds a textual indication of what mechanism, if       * any, is in use to compensate for color/intensity drift over time.       *
       * The attribute is of type string.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public string GetCompensationText(long refreshPeriod)
       {
           if (_attributes[ATTR_COMPENSATIONTEXT].IsLastValueCurrent(refreshPeriod))
           {
               return (string)_attributes[ATTR_COMPENSATIONTEXT].LastValue;
           }

           return (string)ReadSync(_attributes[ATTR_COMPENSATIONTEXT]);
       }


       /**
       * Get the ColorTemperature attribute [attribute ID7].
       *
       * The ColorTemperature attribute contains a scaled inverse of the current value of       * the color temperature. It is updated as fast as practical during commands that       * change the color.       * <p>       * The color temperature value in Kelvins shall be related to the ColorTemperature       * attribute by the relationship       * <p>       * Color temperature = 1,000,000 / ColorTemperature (ColorTemperature in the       * range 1 to 65279 inclusive, giving a color temperature range from 1,000,000       * Kelvins to 15.32 Kelvins).       * <p>       * The value ColorTemperature = 0 indicates an undefined value. The value       * ColorTemperature = 65535 indicates an invalid value.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorTemperatureAsync()
       {
           return Read(_attributes[ATTR_COLORTEMPERATURE]);
       }

       /**
       * Synchronously Get the ColorTemperature attribute [attribute ID7].
       *
       * The ColorTemperature attribute contains a scaled inverse of the current value of       * the color temperature. It is updated as fast as practical during commands that       * change the color.       * <p>       * The color temperature value in Kelvins shall be related to the ColorTemperature       * attribute by the relationship       * <p>       * Color temperature = 1,000,000 / ColorTemperature (ColorTemperature in the       * range 1 to 65279 inclusive, giving a color temperature range from 1,000,000       * Kelvins to 15.32 Kelvins).       * <p>       * The value ColorTemperature = 0 indicates an undefined value. The value       * ColorTemperature = 65535 indicates an invalid value.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorTemperature(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORTEMPERATURE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORTEMPERATURE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORTEMPERATURE]);
       }


       /**
       * Set reporting for the ColorTemperature attribute [attribute ID7].
       *
       * The ColorTemperature attribute contains a scaled inverse of the current value of       * the color temperature. It is updated as fast as practical during commands that       * change the color.       * <p>       * The color temperature value in Kelvins shall be related to the ColorTemperature       * attribute by the relationship       * <p>       * Color temperature = 1,000,000 / ColorTemperature (ColorTemperature in the       * range 1 to 65279 inclusive, giving a color temperature range from 1,000,000       * Kelvins to 15.32 Kelvins).       * <p>       * The value ColorTemperature = 0 indicates an undefined value. The value       * ColorTemperature = 65535 indicates an invalid value.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetColorTemperatureReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_COLORTEMPERATURE], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the ColorMode attribute [attribute ID8].
       *
       * The ColorMode attribute indicates which attributes are currently determining the color of the device.       * If either the CurrentHue or CurrentSaturation attribute is implemented, this attribute SHALL also be       * implemented, otherwise it is optional. The value of the ColorMode attribute cannot be written directly       * - it is set upon reception of another command in to the appropriate mode for that command.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorModeAsync()
       {
           return Read(_attributes[ATTR_COLORMODE]);
       }

       /**
       * Synchronously Get the ColorMode attribute [attribute ID8].
       *
       * The ColorMode attribute indicates which attributes are currently determining the color of the device.       * If either the CurrentHue or CurrentSaturation attribute is implemented, this attribute SHALL also be       * implemented, otherwise it is optional. The value of the ColorMode attribute cannot be written directly       * - it is set upon reception of another command in to the appropriate mode for that command.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetColorMode(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORMODE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_COLORMODE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_COLORMODE]);
       }


       /**
       * Get the EnhancedCurrentHue attribute [attribute ID16384].
       *
       * The EnhancedCurrentHueattribute represents non-equidistant steps along the CIE 1931 color       * triangle, and it provides 16-bits precision. The upper 8 bits of this attribute SHALL be       * used as an index in the implementation specific XY lookup table to provide the non-equidistance       * steps (see the ZLL test specification for an example).  The lower 8 bits SHALL be used to       * interpolate between these steps in a linear way in order to provide color zoom for the user.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetEnhancedCurrentHueAsync()
       {
           return Read(_attributes[ATTR_ENHANCEDCURRENTHUE]);
       }

       /**
       * Synchronously Get the EnhancedCurrentHue attribute [attribute ID16384].
       *
       * The EnhancedCurrentHueattribute represents non-equidistant steps along the CIE 1931 color       * triangle, and it provides 16-bits precision. The upper 8 bits of this attribute SHALL be       * used as an index in the implementation specific XY lookup table to provide the non-equidistance       * steps (see the ZLL test specification for an example).  The lower 8 bits SHALL be used to       * interpolate between these steps in a linear way in order to provide color zoom for the user.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetEnhancedCurrentHue(long refreshPeriod)
       {
           if (_attributes[ATTR_ENHANCEDCURRENTHUE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ENHANCEDCURRENTHUE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ENHANCEDCURRENTHUE]);
       }


       /**
       * Set reporting for the EnhancedCurrentHue attribute [attribute ID16384].
       *
       * The EnhancedCurrentHueattribute represents non-equidistant steps along the CIE 1931 color       * triangle, and it provides 16-bits precision. The upper 8 bits of this attribute SHALL be       * used as an index in the implementation specific XY lookup table to provide the non-equidistance       * steps (see the ZLL test specification for an example).  The lower 8 bits SHALL be used to       * interpolate between these steps in a linear way in order to provide color zoom for the user.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @param minInterval minimum reporting period
       * @param maxInterval maximum reporting period
       * @param reportableChange {@link Object} delta required to trigger report
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> SetEnhancedCurrentHueReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_ENHANCEDCURRENTHUE], minInterval, maxInterval, reportableChange);
       }


       /**
       * Get the EnhancedColorMode attribute [attribute ID16385].
       *
       * The EnhancedColorModeattribute specifies which attributes are currently determining the color of the device.       * To provide compatibility with standard ZCL, the original ColorModeattribute SHALLindicate ‘CurrentHueand CurrentSaturation’       * when the light uses the EnhancedCurrentHueattribute.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetEnhancedColorModeAsync()
       {
           return Read(_attributes[ATTR_ENHANCEDCOLORMODE]);
       }

       /**
       * Synchronously Get the EnhancedColorMode attribute [attribute ID16385].
       *
       * The EnhancedColorModeattribute specifies which attributes are currently determining the color of the device.       * To provide compatibility with standard ZCL, the original ColorModeattribute SHALLindicate ‘CurrentHueand CurrentSaturation’       * when the light uses the EnhancedCurrentHueattribute.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetEnhancedColorMode(long refreshPeriod)
       {
           if (_attributes[ATTR_ENHANCEDCOLORMODE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ENHANCEDCOLORMODE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ENHANCEDCOLORMODE]);
       }


       /**
       * Get the ColorLoopActive attribute [attribute ID16386].
       *
       * The ColorLoopActive attribute specifies the current active status of the color loop.       * If this attribute has the value 0x00, the color loop SHALLnot be active. If this attribute       * has the value 0x01, the color loop SHALL be active. All other values (0x02 – 0xff) are reserved.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorLoopActiveAsync()
       {
           return Read(_attributes[ATTR_COLORLOOPACTIVE]);
       }

       /**
       * Synchronously Get the ColorLoopActive attribute [attribute ID16386].
       *
       * The ColorLoopActive attribute specifies the current active status of the color loop.       * If this attribute has the value 0x00, the color loop SHALLnot be active. If this attribute       * has the value 0x01, the color loop SHALL be active. All other values (0x02 – 0xff) are reserved.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetColorLoopActive(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORLOOPACTIVE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_COLORLOOPACTIVE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_COLORLOOPACTIVE]);
       }


       /**
       * Get the ColorLoopDirection attribute [attribute ID16387].
       *
       * The ColorLoopDirection attribute specifies the current direction of the color loop.       * If this attribute has the value 0x00, the EnhancedCurrentHue attribute SHALL be decremented.       * If this attribute has the value 0x01, the EnhancedCurrentHue attribute SHALL be incremented.       * All other values (0x02 – 0xff) are reserved.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorLoopDirectionAsync()
       {
           return Read(_attributes[ATTR_COLORLOOPDIRECTION]);
       }

       /**
       * Synchronously Get the ColorLoopDirection attribute [attribute ID16387].
       *
       * The ColorLoopDirection attribute specifies the current direction of the color loop.       * If this attribute has the value 0x00, the EnhancedCurrentHue attribute SHALL be decremented.       * If this attribute has the value 0x01, the EnhancedCurrentHue attribute SHALL be incremented.       * All other values (0x02 – 0xff) are reserved.       *
       * The attribute is of type byte.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public byte GetColorLoopDirection(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORLOOPDIRECTION].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_COLORLOOPDIRECTION].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_COLORLOOPDIRECTION]);
       }


       /**
       * Get the ColorLoopTime attribute [attribute ID16388].
       *
       * The ColorLoopTime attribute specifies the number of seconds it SHALL take to perform a full       * color loop, i.e.,to cycle all values of the EnhancedCurrentHue attribute (between 0x0000 and 0xffff).       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorLoopTimeAsync()
       {
           return Read(_attributes[ATTR_COLORLOOPTIME]);
       }

       /**
       * Synchronously Get the ColorLoopTime attribute [attribute ID16388].
       *
       * The ColorLoopTime attribute specifies the number of seconds it SHALL take to perform a full       * color loop, i.e.,to cycle all values of the EnhancedCurrentHue attribute (between 0x0000 and 0xffff).       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorLoopTime(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORLOOPTIME].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORLOOPTIME].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORLOOPTIME]);
       }


       /**
       * Get the ColorLoopStartHue attribute [attribute ID16389].
       *
       * The ColorLoopStartEnhancedHueattribute specifies the value of the EnhancedCurrentHue attribute       * from which the color loop SHALL be started.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorLoopStartHueAsync()
       {
           return Read(_attributes[ATTR_COLORLOOPSTARTHUE]);
       }

       /**
       * Synchronously Get the ColorLoopStartHue attribute [attribute ID16389].
       *
       * The ColorLoopStartEnhancedHueattribute specifies the value of the EnhancedCurrentHue attribute       * from which the color loop SHALL be started.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorLoopStartHue(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORLOOPSTARTHUE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORLOOPSTARTHUE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORLOOPSTARTHUE]);
       }


       /**
       * Get the ColorLoopStoredHue attribute [attribute ID16390].
       *
       * The ColorLoopStoredEnhancedHue attribute specifies the value of the EnhancedCurrentHue attribute       * before the color loop was started. Once the color loop is complete, the EnhancedCurrentHue       * attribute SHALL be restored to this value.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorLoopStoredHueAsync()
       {
           return Read(_attributes[ATTR_COLORLOOPSTOREDHUE]);
       }

       /**
       * Synchronously Get the ColorLoopStoredHue attribute [attribute ID16390].
       *
       * The ColorLoopStoredEnhancedHue attribute specifies the value of the EnhancedCurrentHue attribute       * before the color loop was started. Once the color loop is complete, the EnhancedCurrentHue       * attribute SHALL be restored to this value.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorLoopStoredHue(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORLOOPSTOREDHUE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORLOOPSTOREDHUE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORLOOPSTOREDHUE]);
       }


       /**
       * Get the ColorCapabilities attribute [attribute ID16394].
       *
       * The ColorCapabilitiesattribute specifies the color capabilities of the device supporting the       * color control cluster.       * <p>       * Note:The support of the CurrentXand CurrentYattributes is mandatory regardless of color capabilities.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorCapabilitiesAsync()
       {
           return Read(_attributes[ATTR_COLORCAPABILITIES]);
       }

       /**
       * Synchronously Get the ColorCapabilities attribute [attribute ID16394].
       *
       * The ColorCapabilitiesattribute specifies the color capabilities of the device supporting the       * color control cluster.       * <p>       * Note:The support of the CurrentXand CurrentYattributes is mandatory regardless of color capabilities.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorCapabilities(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORCAPABILITIES].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORCAPABILITIES].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORCAPABILITIES]);
       }


       /**
       * Get the ColorTemperatureMin attribute [attribute ID16395].
       *
       * The ColorTempPhysicalMinMiredsattribute indicates the minimum mired value       * supported by the hardware. ColorTempPhysicalMinMiredscorresponds to the maximum       * color temperature in kelvins supported by the hardware.       * ColorTempPhysicalMinMireds ≤ ColorTemperatureMireds       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorTemperatureMinAsync()
       {
           return Read(_attributes[ATTR_COLORTEMPERATUREMIN]);
       }

       /**
       * Synchronously Get the ColorTemperatureMin attribute [attribute ID16395].
       *
       * The ColorTempPhysicalMinMiredsattribute indicates the minimum mired value       * supported by the hardware. ColorTempPhysicalMinMiredscorresponds to the maximum       * color temperature in kelvins supported by the hardware.       * ColorTempPhysicalMinMireds ≤ ColorTemperatureMireds       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorTemperatureMin(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORTEMPERATUREMIN].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORTEMPERATUREMIN].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORTEMPERATUREMIN]);
       }


       /**
       * Get the ColorTemperatureMax attribute [attribute ID16396].
       *
       * The ColorTempPhysicalMaxMiredsattribute indicates the maximum mired value       * supported by the hard-ware. ColorTempPhysicalMaxMiredscorresponds to the minimum       * color temperature in kelvins supported by the hardware.       * ColorTemperatureMireds ≤ ColorTempPhysicalMaxMireds.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> GetColorTemperatureMaxAsync()
       {
           return Read(_attributes[ATTR_COLORTEMPERATUREMAX]);
       }

       /**
       * Synchronously Get the ColorTemperatureMax attribute [attribute ID16396].
       *
       * The ColorTempPhysicalMaxMiredsattribute indicates the maximum mired value       * supported by the hard-ware. ColorTempPhysicalMaxMiredscorresponds to the minimum       * color temperature in kelvins supported by the hardware.       * ColorTemperatureMireds ≤ ColorTempPhysicalMaxMireds.       *
       * The attribute is of type ushort.
       *
       * The implementation of this attribute by a device is OPTIONAL
       *
       * @return the Task<CommandResult> command result Task
       */
       public ushort GetColorTemperatureMax(long refreshPeriod)
       {
           if (_attributes[ATTR_COLORTEMPERATUREMAX].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_COLORTEMPERATUREMAX].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_COLORTEMPERATUREMAX]);
       }


       /**
       * The Move to Hue Command
       *
       * @param hue {@link byte} Hue
       * @param direction {@link byte} Direction
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveToHueCommand(byte hue, byte direction, ushort transitionTime)
       {
           MoveToHueCommand command = new MoveToHueCommand();

           // Set the fields
           command.Hue = hue;
           command.Direction = direction;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move Hue Command
       *
       * @param moveMode {@link byte} Move mode
       * @param rate {@link byte} Rate
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveHueCommand(byte moveMode, byte rate)
       {
           MoveHueCommand command = new MoveHueCommand();

           // Set the fields
           command.MoveMode = moveMode;
           command.Rate = rate;

           return Send(command);
       }

       /**
       * The Step Hue Command
       *
       * @param stepMode {@link byte} Step mode
       * @param stepSize {@link byte} Step size
       * @param transitionTime {@link byte} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> StepHueCommand(byte stepMode, byte stepSize, byte transitionTime)
       {
           StepHueCommand command = new StepHueCommand();

           // Set the fields
           command.StepMode = stepMode;
           command.StepSize = stepSize;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move to Saturation Command
       *
       * @param saturation {@link byte} Saturation
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveToSaturationCommand(byte saturation, ushort transitionTime)
       {
           MoveToSaturationCommand command = new MoveToSaturationCommand();

           // Set the fields
           command.Saturation = saturation;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move Saturation Command
       *
       * @param moveMode {@link byte} Move mode
       * @param rate {@link byte} Rate
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveSaturationCommand(byte moveMode, byte rate)
       {
           MoveSaturationCommand command = new MoveSaturationCommand();

           // Set the fields
           command.MoveMode = moveMode;
           command.Rate = rate;

           return Send(command);
       }

       /**
       * The Step Saturation Command
       *
       * @param stepMode {@link byte} Step mode
       * @param stepSize {@link byte} Step size
       * @param transitionTime {@link byte} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> StepSaturationCommand(byte stepMode, byte stepSize, byte transitionTime)
       {
           StepSaturationCommand command = new StepSaturationCommand();

           // Set the fields
           command.StepMode = stepMode;
           command.StepSize = stepSize;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move to Hue and Saturation Command
       *
       * @param hue {@link byte} Hue
       * @param saturation {@link byte} Saturation
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveToHueAndSaturationCommand(byte hue, byte saturation, ushort transitionTime)
       {
           MoveToHueAndSaturationCommand command = new MoveToHueAndSaturationCommand();

           // Set the fields
           command.Hue = hue;
           command.Saturation = saturation;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move to Color Command
       *
       * @param colorX {@link ushort} ColorX
       * @param colorY {@link ushort} ColorY
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveToColorCommand(ushort colorX, ushort colorY, ushort transitionTime)
       {
           MoveToColorCommand command = new MoveToColorCommand();

           // Set the fields
           command.ColorX = colorX;
           command.ColorY = colorY;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move Color Command
       *
       * @param rateX {@link short} RateX
       * @param rateY {@link short} RateY
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveColorCommand(short rateX, short rateY)
       {
           MoveColorCommand command = new MoveColorCommand();

           // Set the fields
           command.RateX = rateX;
           command.RateY = rateY;

           return Send(command);
       }

       /**
       * The Step Color Command
       *
       * @param stepX {@link short} StepX
       * @param stepY {@link short} StepY
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> StepColorCommand(short stepX, short stepY, ushort transitionTime)
       {
           StepColorCommand command = new StepColorCommand();

           // Set the fields
           command.StepX = stepX;
           command.StepY = stepY;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Move to Color Temperature Command
       *
       * @param colorTemperature {@link ushort} Color Temperature
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> MoveToColorTemperatureCommand(ushort colorTemperature, ushort transitionTime)
       {
           MoveToColorTemperatureCommand command = new MoveToColorTemperatureCommand();

           // Set the fields
           command.ColorTemperature = colorTemperature;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Enhanced Move To Hue Command
       *
       * @param hue {@link ushort} Hue
       * @param direction {@link byte} Direction
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> EnhancedMoveToHueCommand(ushort hue, byte direction, ushort transitionTime)
       {
           EnhancedMoveToHueCommand command = new EnhancedMoveToHueCommand();

           // Set the fields
           command.Hue = hue;
           command.Direction = direction;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Enhanced Step Hue Command
       *
       * @param stepMode {@link byte} Step Mode
       * @param stepSize {@link ushort} Step Size
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> EnhancedStepHueCommand(byte stepMode, ushort stepSize, ushort transitionTime)
       {
           EnhancedStepHueCommand command = new EnhancedStepHueCommand();

           // Set the fields
           command.StepMode = stepMode;
           command.StepSize = stepSize;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Enhanced Move To Hue and Saturation Command
       *
       * @param hue {@link ushort} Hue
       * @param saturation {@link byte} Saturation
       * @param transitionTime {@link ushort} Transition time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> EnhancedMoveToHueAndSaturationCommand(ushort hue, byte saturation, ushort transitionTime)
       {
           EnhancedMoveToHueAndSaturationCommand command = new EnhancedMoveToHueAndSaturationCommand();

           // Set the fields
           command.Hue = hue;
           command.Saturation = saturation;
           command.TransitionTime = transitionTime;

           return Send(command);
       }

       /**
       * The Color Loop Set Command
       *
       * @param updateFlags {@link byte} Update Flags
       * @param action {@link byte} Action
       * @param direction {@link byte} Direction
       * @param transitionTime {@link ushort} Transition time
       * @param startHue {@link ushort} Start Hue
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> ColorLoopSetCommand(byte updateFlags, byte action, byte direction, ushort transitionTime, ushort startHue)
       {
           ColorLoopSetCommand command = new ColorLoopSetCommand();

           // Set the fields
           command.UpdateFlags = updateFlags;
           command.Action = action;
           command.Direction = direction;
           command.TransitionTime = transitionTime;
           command.StartHue = startHue;

           return Send(command);
       }

       public override ZclCommand GetCommandFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // MOVE_TO_HUE_COMMAND
                   return new MoveToHueCommand();
               case 1: // MOVE_HUE_COMMAND
                   return new MoveHueCommand();
               case 2: // STEP_HUE_COMMAND
                   return new StepHueCommand();
               case 3: // MOVE_TO_SATURATION_COMMAND
                   return new MoveToSaturationCommand();
               case 4: // MOVE_SATURATION_COMMAND
                   return new MoveSaturationCommand();
               case 5: // STEP_SATURATION_COMMAND
                   return new StepSaturationCommand();
               case 6: // MOVE_TO_HUE_AND_SATURATION_COMMAND
                   return new MoveToHueAndSaturationCommand();
               case 7: // MOVE_TO_COLOR_COMMAND
                   return new MoveToColorCommand();
               case 8: // MOVE_COLOR_COMMAND
                   return new MoveColorCommand();
               case 9: // STEP_COLOR_COMMAND
                   return new StepColorCommand();
               case 10: // MOVE_TO_COLOR_TEMPERATURE_COMMAND
                   return new MoveToColorTemperatureCommand();
               case 64: // ENHANCED_MOVE_TO_HUE_COMMAND
                   return new EnhancedMoveToHueCommand();
               case 65: // ENHANCED_STEP_HUE_COMMAND
                   return new EnhancedStepHueCommand();
               case 66: // ENHANCED_MOVE_TO_HUE_AND_SATURATION_COMMAND
                   return new EnhancedMoveToHueAndSaturationCommand();
               case 67: // COLOR_LOOP_SET_COMMAND
                   return new ColorLoopSetCommand();
                   default:
                       return null;
           }
       }
   }
}
