using System;
using JetBrains.Annotations;
using Skattergy.GUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Skattergy.Core
{
    public class PlayerResource : IDisplayable
    {
        public Resource Resource { get; }
        public ulong Amount { get; set; }
        public string DisplayName { get; }

        private TextMeshProUGUI _display;
        
        public PlayerResource(Resource resource, ulong amount)
        {
            Resource = resource;
            Amount = amount;
            DisplayName = Enum.GetName(typeof(Resource), Resource);
        }

        public void Add(ulong amount)
        {
            Amount += amount;
        }

        public bool Remove(ulong amount)
        {
            if (amount > Amount) return false;
            Amount -= amount;
            return true;
        }

        public void Display()
        {
            _display.text = $"{DisplayName}: {Amount}";
        }

        public void Instantiate([CanBeNull] GameObject context)
        {
            var view = GameObject.Instantiate(Resources.Load("GUI/ResourceView")) as GameObject;

            var display = view.GetComponent<TextMeshProUGUI>();
            
            // amount of children in the scrollview -- needed for knowing how much to offset vertically
            var amount = context.transform.childCount;
            
            display.transform.SetParent(context.transform, false); // god knows what this is, thanks unity

            var rect = display.rectTransform;
            // offset
            rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 
                (amount * display.rectTransform.rect.height) + display.rectTransform.rect.height / 2, 0);
            
            _display = display;
            
        }
    }
}