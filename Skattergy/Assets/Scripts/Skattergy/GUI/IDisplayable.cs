using UnityEngine;

namespace Skattergy.GUI
{
    public interface IDisplayable
    {
        string DisplayName { get; }
        void Display();
        void Instantiate(GameObject context);
    }
}