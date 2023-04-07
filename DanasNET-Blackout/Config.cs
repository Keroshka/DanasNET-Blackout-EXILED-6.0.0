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
        public int MinTimeCooldown { get; set; } = 240;
        public int MaxTimeCooldown { get; set; } = 420;
        public int MinBlackoutTime { get; set; } = 30;
        public int MaxBlackoutTime { get; set; } = 60;
        public int BlackoutChance { get; set; } = 50;
    }
}
