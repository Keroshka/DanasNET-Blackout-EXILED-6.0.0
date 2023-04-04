using System.Collections;
using UnityEngine;

namespace DanasNET_Blackout
{
    public class EventHandlers
    {
        private Plugin _plugin;

        public EventHandlers(Plugin plugin)
        {
            _plugin = plugin;
            blackoutCooldown = plugin.rng.Next(_plugin.Config.minTime, _plugin.Config.maxTime);
        }

        public float blackoutCooldown { get; private set; }


        public IEnumerator BlackoutTimeout()
        {
            yield return new WaitForSeconds(blackoutCooldown);
        }

        public void OnRoundStarted()
        {

        }
    }
}