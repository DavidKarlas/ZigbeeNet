//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Digi.XBee.Internal.Protocol
{
    
    
    /// <summary>
    /// Class to implement the XBee command " Get Encryption Enable ".
    /// AT Command <b>EE</b></p>Set or read the encryption enable setting.
    ///This class provides methods for processing XBee API commands.
    ///
    /// </summary>
    public class XBeeGetEncryptionEnableCommand : XBeeFrame, IXBeeCommand 
    {
        
        /// <summary>
        /// 
        /// </summary>
        private int _frameId;
        
        public void SetFrameId(int frameId)
        {
            this._frameId = frameId;
        }
    }
}
