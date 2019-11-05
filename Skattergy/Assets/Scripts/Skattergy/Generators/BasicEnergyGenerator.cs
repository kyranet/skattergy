using Skattergy.Core;

namespace Skattergy.Generators
{
    public class BasicEnergyGenerator : IGenerator
    {
        public Building Kind => Building.BasicEnergyGenerator;
        public byte Level => 0;
        public bool CanBuild => true; // TODO: Add cost logic
        public bool CanUpgrade => true; // TODO: Add cost logic

        public WorldPosition Position { get; } // ignore for now, we'll implement actual positioning later
        
        public void Tick(World context)
        {
            context.PlayerResourceAmount[Resource].Add(ResourceGenerationPerTick);
        }

        public Resource Resource => Resource.Energy;
        public ulong ResourceGenerationPerTick => 10;
        public Resource? RequiredResource => null;
        public ulong? RequiredResourcePerTick => null;
    }
}