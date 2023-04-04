using System.Collections;
using UnityEngine;
using MEC;
using System.Collections.Generic;

namespace DanasNET_Blackout
{
    public class EventHandlers
    {
        private readonly Plugin _plugin;
        private float BlackoutCooldown { get;  set; }
        private float BlackoutTime { get;  set; }
        private bool AreTeslasEnabled { get; set; } = true;

        public EventHandlers(Plugin plugin)
        {
            _plugin = plugin;
            ResetCooldown();
        }

        private void ResetCooldown()
        {
            BlackoutCooldown = _plugin.rng.Next(_plugin.Config.MinTimeCooldown, _plugin.Config.MaxTimeCooldown);
            BlackoutTime = _plugin.rng.Next(_plugin.Config.MinBlackoutTime, _plugin.Config.MaxBlackoutTime);
        }

        public IEnumerator<float> BlackoutTimeout()
        {
            for (; ; )
            {
                yield return Timing.WaitForSeconds(BlackoutCooldown);
                Blackout();
                ResetCooldown();
            }
        }

        public IEnumerator<float> EnableTeslas()
        {
            yield return Timing.WaitForSeconds(BlackoutTime);
            Exiled.API.Features.Cassie.Message("jam_025_9 POWER SYSTEM jam_025_9 OPERATIONAL");
            AreTeslasEnabled = true;
        }

        private void Blackout()//pitch_0.30 .G5 pitch_0.20 .g3 jam_025_9 pitch_0.10 .G1
        {
            Exiled.API.Features.Cassie.Message("pitch_0.30 .G5 pitch_0.20 .g3 jam_025_9 pitch_0.10 .G1");
            switch (_plugin.rng.Next(3))
            {
                case 0:
                    Exiled.API.Features.Cassie.Message("pitch_0.30 .G5 pitch_0.20 .g3 jam_025_9 pitch_0.10 .G1");
                    break;
                case 1:
                    Exiled.API.Features.Cassie.Message("pitch_2.50 .G3 .G3 .G3 .G3 .G3 pitch_0.20 .G6 jam_025_9 .G4");
                    break;
                case 2:
                    Exiled.API.Features.Cassie.Message("pitch_1.50 .G4 jam_025_9 pitch_0.15 .G2 pitch_0.4 .G6 pitch_0.1 jam_045_9 .G7 ");
                    break;
                default:
                    Exiled.API.Features.Cassie.Message("pitch_1.50 .G4 jam_025_9 pitch_0.15 .G2 pitch_0.4 .G6 pitch_0.1 jam_045_9 .G7 ");
                    break;
            }
            Exiled.API.Features.Map.TurnOffAllLights(BlackoutTime);
            AreTeslasEnabled = false;
            Timing.RunCoroutine(EnableTeslas());
        }

        public void OnRoundStarted()
        {
            if (_plugin.rng.Next(100) <= _plugin.Config.BlackoutChance)
            {
                Timing.RunCoroutine(BlackoutTimeout());
            }
        }

        public void OnTeslaTrigger(Exiled.Events.EventArgs.Player.TriggeringTeslaEventArgs ev)
        {
            if (!AreTeslasEnabled)
            {
                ev.IsAllowed = false;
            }
        }
    }
}