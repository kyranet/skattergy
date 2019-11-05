using System.Collections.Generic;
using Skattergy.Generators;

namespace Skattergy.Core
{
    public class World
    {
        public Dictionary<Resource, PlayerResource> PlayerResourceAmount { get; }
        private IEnumerable<ITickable> Tickables { get; }
        
        public World()
        {
            PlayerResourceAmount = new Dictionary<Resource, PlayerResource>
            {
                [Resource.Energy] = new PlayerResource(Resource.Energy, 0UL),
                [Resource.Fuel] = new PlayerResource(Resource.Fuel, 0UL),
                [Resource.AdvancedBuilding] = new PlayerResource(Resource.AdvancedBuilding, 0UL),
                [Resource.BasicBuilding] = new PlayerResource(Resource.BasicBuilding, 0UL)
            };
            Tickables = new List<ITickable>
            {
                new EnergyGenerator()
            };
        }
        
        public void Tick()
        {
            foreach (var tickable in Tickables)
            {
                tickable.Tick(this);
            }
        }
        
    }
}