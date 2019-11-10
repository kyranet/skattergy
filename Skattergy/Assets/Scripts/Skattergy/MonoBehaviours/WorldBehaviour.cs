using System;
using System.Collections;
using Skattergy.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Skattergy.MonoBehaviours
{
    public class WorldBehaviour : MonoBehaviour
    {

        [SerializeField]
        private GameObject _gui;

        private World _world;
        private const float TickSeconds = 0.5f;

        private void Awake()
        {
            Debug.Log("GUI");
            Debug.Log(_gui);
            _world = new World {View = _gui};
            _world.CreateViewModel();
        }

        private void OnEnable()
        {
            StartCoroutine(OnTick());
        }

        private IEnumerator OnTick()
        {
            while (enabled)
            {
                _world.Tick();
                yield return new WaitForSeconds(TickSeconds);
            }
        }
    }
}
