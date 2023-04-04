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
            AreTeslasEnabled = true;
        }

        private void Blackout()
        {
            Exiled.API.Features.Cassie.GlitchyMessage("POWER .g4 OUTAGE .g2 ALERT", 0.2f, 0.2f);
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