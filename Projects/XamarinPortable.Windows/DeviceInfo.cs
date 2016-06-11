using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;

namespace PlatformInfo.Windows
{
    public class DeviceInfo : IDeviceInfo
    {
        EasClientDeviceInformation vDeviceInfo = new EasClientDeviceInformation();
        public String Model
        {
            get { return String.Format("{0} {1}", vDeviceInfo.SystemManufacturer, vDeviceInfo.SystemProductName); }
        }

        public String Version
        {
            get { return vDeviceInfo.OperatingSystem; }
        }
    }
}
