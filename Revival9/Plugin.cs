using Exiled.API.Features;
using Random = System.Random;

namespace Revival
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "Revival";
        public override string Name => "Revival";
        public override string Author => "angelseraphim.";

        public static Plugin plugin;
        public static Coroutines coroutine;
        public static Random random;

        public override void OnEnabled()
        {
            plugin = this;
            random = new Random();
            coroutine = new Coroutines();

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            plugin = null;
            random = null;
            coroutine = null;

            base.OnDisabled();
        }
    }
}
