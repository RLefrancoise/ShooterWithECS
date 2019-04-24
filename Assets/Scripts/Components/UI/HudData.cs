using System;
using Unity.Entities;

namespace Components.UI
{
    [Serializable]
    public struct HudData : IComponentData
    {
        public float health;
        public float power;
    }
}