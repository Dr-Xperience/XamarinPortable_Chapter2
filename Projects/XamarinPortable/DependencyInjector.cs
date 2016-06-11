using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency
{
    public class DependencyInjector
    {
        private PlatformInfo.IDeviceInfo device;
        public PlatformInfo.IDeviceInfo Device
        {
            get { return device; }
            set { device = value; }
        }
        private static DependencyInjector obj = null;

        private DependencyInjector()
        {

        }

        public static DependencyInjector getDependencyInjector()
        {
            if (obj == null)
            {
                obj = new DependencyInjector();
            }
            return obj;
        }
    }
}
