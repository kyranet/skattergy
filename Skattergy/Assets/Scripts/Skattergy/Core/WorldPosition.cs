using System.Collections.Generic;
using UnityEngine;

namespace Skattergy.Core
{
    public struct WorldPosition
    {
        public Vector2 Position { get; }
        public Dictionary<Resource, int> ResourceValues { get; }
    }
}