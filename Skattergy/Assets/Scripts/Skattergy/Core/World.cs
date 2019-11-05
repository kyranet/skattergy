using System.Collections.Generic;
using System.Linq;
using Skattergy.Generators;

namespace Skattergy.Core
{
    public class World
    {
        public Dictionary<Resource, int> PlayerResourceAmount { get; }
        private IEnumerable<ITickable> Tickables { get; }
        
        public World()
        {
            PlayerResourceAmount = new Dictionary<Resource, int>
            {
                [Resource.Energy] = 0,
                [Resource.Fuel] = 0,
                [Resource.AdvancedBuilding] = 0,
                [Resource.BasicBuilding] = 0
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