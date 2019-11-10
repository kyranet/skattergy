using Skattergy.Core;
using UnityEngine;

namespace Skattergy.GUI
{
    public class ResourceViewModel
    {
        private readonly World _context;
        public ResourceViewModel(World context, GameObject viewContext)
        {
            _context = context;
            foreach (var value in context.PlayerResources.Values)
            {
                value.Instantiate(viewContext);
            }
        }

        public void Update()
        {
            foreach (var value in _context.PlayerResources.Values)
            {
                value.Display();
            }
        }
    }
}