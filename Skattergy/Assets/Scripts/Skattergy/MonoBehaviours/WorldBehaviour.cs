using System;
using System.Collections;
using System.Collections.Generic;
using Skattergy.Core;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Skattergy.MonoBehaviours
{
    public class WorldBehaviour : MonoBehaviour
    {

        public GameObject EnergyGenerator { get; set; }
        private World World;
        private const float TickSeconds = 0.5f;

        private void Awake()
        {
            World = new World();
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
                yield return new WaitForSeconds(TickSeconds);
            }
        }
    }
}
