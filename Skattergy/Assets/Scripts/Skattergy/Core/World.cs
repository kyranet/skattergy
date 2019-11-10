using System.Collections.Generic;
using Skattergy.Generators;
using Skattergy.GUI;
using UnityEngine;

namespace Skattergy.Core
{
    public class World
    {
        public Dictionary<Building, IGenerator> PlayerBuildables { get; }
        public Dictionary<Resource, PlayerResource> PlayerResources { get; }
        
        public GameObject View { get; set; }
        private IEnumerable<ITickable> Tickables { get; }

        private ResourceViewModel _viewModel;
        
        
        public World()
        {

            PlayerBuildables = new Dictionary<Building, IGenerator>
            {
                [Building.BasicEnergyGenerator] = new BasicEnergyGenerator(),
                [Building.AdvancedEnergyGenerator] = new AdvancedEnergyGenerator()
            };
            PlayerResources = new Dictionary<Resource, PlayerResource>
            {
                [Resource.Energy] = new PlayerResource(Resource.Energy, 0UL),
                [Resource.Fuel] = new PlayerResource(Resource.Fuel, 0UL),
                [Resource.AdvancedBuilding] = new PlayerResource(Resource.AdvancedBuilding, 0UL),
                [Resource.BasicBuilding] = new PlayerResource(Resource.BasicBuilding, 0UL)
            };
            Tickables = new List<ITickable>
            {
                PlayerBuildables[Building.BasicEnergyGenerator],
                PlayerBuildables[Building.AdvancedEnergyGenerator]
            };
        }

        public void CreateViewModel()
        {
            _viewModel = new ResourceViewModel(this, View);
        }

        public void Tick()
        {
            foreach (var tickable in Tickables)
            {
                tickable.Tick(this);
            }
            
            _viewModel.Update();
        }
        
    }
}