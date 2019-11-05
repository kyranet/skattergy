using Skattergy.Core;
using Debug = System.Diagnostics.Debug;

namespace Skattergy.Generators
{
    public class AdvancedEnergyGenerator : IGenerator
    {
        public Building Kind => Building.AdvancedEnergyGenerator;
        public byte Level => 0;
        public bool CanBuild => true; // TODO: Add cost logic
        public bool CanUpgrade => true; // TODO: Add cost logic

        public WorldPosition Position { get; } // ignore for now, we'll implement actual positioning later
        
        public void Tick(World context)
        {
            Debug.Assert(RequiredResource != null, nameof(RequiredResource) + " != null");
            Debug.Assert(RequiredResourcePerTick != null, nameof(RequiredResourcePerTick) + " != null");

            if (context.PlayerResourceAmount[(Resource) RequiredResource].Remove((ulong) RequiredResourcePerTick))
                context.PlayerResourceAmount[Resource].Add(ResourceGenerationPerTick);
        }

        public Resource Resource => Resource.Energy;
        
        // this would probably be injected via a constructor based on the current position of the building
        // for the resource generation per tick (perhaps for a mine, you put it on a high value spot, TBD)
        public ulong ResourceGenerationPerTick => 10;
        public Resource? RequiredResource => Resource.Fuel;
        public ulong? RequiredResourcePerTick => 8;
    }
}