using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoBuoysMod
{
    [ConfigurationPath("NoBuoysMod.xml")]
    public class NoBuoysModConfig
    {
        public bool NoBuoysEnabled { get; set; } = true;
    }
}
