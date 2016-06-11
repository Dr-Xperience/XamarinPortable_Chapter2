using PlatformInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;

namespace PlatformInfo.UWP
{
    class DeviceInfo : IDeviceInfo
    {
        EasClientDeviceInformation vDeviceInfo = new EasClientDeviceInformation();
        public string Model
        {
            get
            {
                return String.Format("{0} {1}", vDeviceInfo.SystemManufacturer, vDeviceInfo.SystemProductName);
            }
        }

        public string Version
        {
            get
            {
                return vDeviceInfo.OperatingSystem;
            }
        }
    }
}
