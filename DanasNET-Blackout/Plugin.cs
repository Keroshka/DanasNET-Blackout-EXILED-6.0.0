using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanasNET_Blackout
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Keroshka";
        public override string Name { get; } = "DanasDotNET-Blackout";
        public override Version Version { get; } = new Version(1, 0, 0);

        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);

        public static Plugin Instance = new Plugin();

        public EventHandlers EventHandler { get; private set; }

        public Random rng = new Random();

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}
