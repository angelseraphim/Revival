using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Revival
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Revive chance")]
        public int Chance { get; set; } = 10;

        [Description("Time to Spawn")]
        public int Expectation { get; set; } = 30;

        [Description("Timer text")]
        public string TimerText { get; set; } = "Reviving player... %timer%";

        [Description("If the body was destroyed")]
        public string RagdollDestroyed { get; set; } = "The body is destroyed.. It is not possible to revive the player..";

        [Description("If a player leaves the game")]
        public string TargetDisconnected { get; set; } = "The soul has left the body, it is impossible to revive";

        [Description("If a player changed role")]
        public string TargetChangedRole { get; set; } = "The soul has left the body, it is impossible to revive";

        [Description("Command config")]
        public CommandSettings command { get; set; } = new CommandSettings();
    }
    public class CommandSettings
    {
        [Description("Command name")]
        public string CommandName { get; set; } = "revive";

        [Description("Command description")]
        public string Description { get; set; } = "Revive a player";

        [Description("If the player does not have a medkit in his hands")]
        public string CurrentItem { get; set; } = "Please take a medkit";

        [Description("If the player is not looking at the ragdoll or ragdoll is null")]
        public string RagdollNotFound { get; set; } = "Ragdoll not found";

        [Description("If the player is unlucky with the chance")]
        public string NoLuck { get; set; } = "Unluck XD";

        [Description("If the command is executed without error")]
        public string Successful { get; set; } = "Successful!!!";
    }
}
