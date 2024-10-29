using Exiled.API.Features;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

namespace Revival
{
    public class Coroutines
    {
        public IEnumerator<float> RevivePlayer(Player player, Ragdoll ragdoll)
        {
            Player target = ragdoll.Owner;
            for (int i = Plugin.plugin.Config.Expectation; i >= 0; i--)
            {
                if (!player.IsConnected)
                    break;
                if (!target.IsConnected)
                {
                    Log.Info("Target disconnected");
                    player.ShowHint(Plugin.plugin.Config.TargetDisconnected);
                    break;
                }
                if (target.IsAlive)
                {
                    Log.Info("Target is alive");
                    player.ShowHint(Plugin.plugin.Config.TargetChangedRole);
                    break;
                }
                if (ragdoll == null)
                {
                    Log.Info("Ragdoll is null");
                    player.ShowHint(Plugin.plugin.Config.RagdollDestroyed);
                    break;
                }

                player.ShowHint(Plugin.plugin.Config.TimerText.Replace("%timer%", i.ToString()));
                //Log.Info(i.ToString());
                if (i == 0)
                {
                    Vector3 position = new Vector3(ragdoll.Position.x, ragdoll.Position.y + 1, ragdoll.Position.z);
                    RoleTypeId role = ragdoll.Role;
                    target.Role.Set(role);
                    target.Broadcast(5, "");
                    Timing.CallDelayed(0.1f, () => target.Position = position);
                    ragdoll.Destroy();
                }
                yield return Timing.WaitForSeconds(1);
            }
            yield break;
        }
    }
}
