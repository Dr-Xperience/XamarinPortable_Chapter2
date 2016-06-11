using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInfo
{
    public interface IDeviceInfo
    {        
        String Model { get; }
        String Version { get;}
    }
}
