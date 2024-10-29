using CommandSystem;
using Exiled.API.Features;
using MEC;
using PlayerRoles.Ragdolls;
using System;
using UnityEngine;

namespace Revival.Command
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class Revive : ICommand
    {
        public string Command { get; } = Plugin.plugin.Config.command.CommandName;

        public string[] Aliases { get; } = { };

        public string Description { get; } = Plugin.plugin.Config.command.Description;


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (player.CurrentItem == null || player.CurrentItem.Type != ItemType.Medkit)
            {
                response = Plugin.plugin.Config.command.CurrentItem;
                return false;
            }
            Physics.Raycast(new Ray(player.CameraTransform.position + (player.CameraTransform.forward * 0.25f), player.CameraTransform.forward), out RaycastHit raycastHit);
            Ragdoll ragdoll = Ragdoll.Get(raycastHit.collider.GetComponentInParent<BasicRagdoll>());
            if (ragdoll == null)
            {
                response = Plugin.plugin.Config.command.RagdollNotFound;
                return false;
            }
            player.CurrentItem.Destroy();
            int Random = Plugin.random.Next(1, 100);
            if (Random > Plugin.plugin.Config.Chance)
            {
                response = Plugin.plugin.Config.command.NoLuck;
                return false;
            }
            Timing.RunCoroutine(Plugin.coroutine.RevivePlayer(player, ragdoll));
            response = Plugin.plugin.Config.command.Successful;
            return true;
        }
    }
}
