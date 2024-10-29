using Exiled.API.Interfaces;

namespace Revival
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public int Chance { get; set; } = 10;
        public int Expectation { get; set; } = 30;
        public string TimerText { get; set; } = "Reviving player... %timer%";
        public string RagdollDestroyed { get; set; } = "The body is destroyed.. It is not possible to revive the player..";
        public string TargetDisconnected { get; set; } = "The soul has left the body, it is impossible to revive";
        public string TargetChangedRole { get; set; } = "The soul has left the body, it is impossible to revive";
        
        public CommandSettings command { get; set; } = new CommandSettings();
    }
    public class CommandSettings
    {
        public string CommandName { get; set; } = "revive";
        public string Description { get; set; } = "Revive a player";
        public string CurrentItem { get; set; } = "Please take a medkit";
        public string RagdollNotFound { get; set; } = "Ragdoll not found";
        public string NoLuck { get; set; } = "Unluck XD";
        public string Successful { get; set; } = "Successful!!!";
    }
}
