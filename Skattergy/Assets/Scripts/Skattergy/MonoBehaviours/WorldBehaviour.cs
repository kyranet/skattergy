using System;
using System.Collections;
using Skattergy.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Skattergy.MonoBehaviours
{
    public class WorldBehaviour : MonoBehaviour
    {
        public GameObject basicEnergyGenerator;
        public GameObject advancedEnergyGenerator;
        public Text resourceBasic;
        public Text resourceAdvanced;
        public Text resourceFuel;
        public Text resourceEnergy;
        private readonly World World = new World();
        private const float TickSeconds = 0.5f;

        private void Awake()
        {
            if (resourceBasic == null) throw new ArgumentNullException();
            if (resourceAdvanced == null) throw new ArgumentNullException();
            if (resourceFuel == null) throw new ArgumentNullException();
            if (resourceEnergy == null) throw new ArgumentNullException();

            if (basicEnergyGenerator == null) throw new ArgumentNullException();
            basicEnergyGenerator.SetActive(World.PlayerBuildables.ContainsKey(Building.BasicEnergyGenerator));

            if (advancedEnergyGenerator == null) throw new ArgumentNullException();
            advancedEnergyGenerator.SetActive(World.PlayerBuildables.ContainsKey(Building.AdvancedEnergyGenerator));
        }

        private void OnEnable()
        {
            StartCoroutine(OnTick());
        }

        private IEnumerator OnTick()
        {
            while (enabled)
            {
                World.Tick();
                resourceBasic.text = World.PlayerResourceAmount[Resource.BasicBuilding].Amount.ToString();
                resourceAdvanced.text = World.PlayerResourceAmount[Resource.AdvancedBuilding].Amount.ToString();
                resourceFuel.text = World.PlayerResourceAmount[Resource.Fuel].Amount.ToString();
                resourceEnergy.text = World.PlayerResourceAmount[Resource.Energy].Amount.ToString();
                yield return new WaitForSeconds(TickSeconds);
            }
        }
    }
}
