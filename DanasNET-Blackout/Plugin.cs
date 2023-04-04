using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events;

namespace DanasNET_Blackout
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Keroshka";
        public override string Name { get; } = "DanasDotNET-Blackout";
        public override Version Version { get; } = new Version(1, 0, 1);

        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);

        public static Plugin Instance = new Plugin();

        public EventHandlers EventHandler { get; private set; }

        public Random rng = new Random();

        public override void OnEnabled()
        {
            EventHandler = new EventHandlers(Instance);

            Exiled.Events.Handlers.Server.RoundStarted += EventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.TriggeringTesla += EventHandler.OnTeslaTrigger;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.TriggeringTesla -= EventHandler.OnTeslaTrigger;

            EventHandler = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}
