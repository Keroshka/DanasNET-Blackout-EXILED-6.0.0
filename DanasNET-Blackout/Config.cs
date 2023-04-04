using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanasNET_Blackout
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public int minTime { get; set; } = 120;
        public int maxTime { get; set; } = 360;
    }
}
