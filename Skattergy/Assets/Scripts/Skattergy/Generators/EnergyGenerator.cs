using Skattergy.Core;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Skattergy.Generators
{
    public class EnergyGenerator : IGenerator
    {
        public ushort Level => 0;
        public bool CanBuild => true; // TODO: Add cost logic
        public bool CanUpgrade => true; // TODO: Add cost logic

        public WorldPosition Position { get; } // ignore for now, we'll implement actual positioning later
        
        public void Tick(World context)
        {
            context.PlayerResourceAmount[Resource] += ResourceGenerationPerTick;
            Debug.Assert(RequiredResource != null, nameof(RequiredResource) + " != null");
            Debug.Assert(RequiredResourcePerTick != null, nameof(RequiredResourcePerTick) + " != null");
            context.PlayerResourceAmount[(Resource)RequiredResource] -= (int)RequiredResourcePerTick;
            // man, I really fucking wish we had nullables from C#8. Sad face emoji.
        }

        public Resource Resource => Resource.Energy;
        
        // this would probably be injected via a constructor based on the current position of the building
        // for the resource generation per tick (perhaps for a mine, you put it on a high value spot, TBD)
        public int ResourceGenerationPerTick => 10;
        public Resource? RequiredResource => Resource.Fuel;
        public int? RequiredResourcePerTick => 8;
    }
}