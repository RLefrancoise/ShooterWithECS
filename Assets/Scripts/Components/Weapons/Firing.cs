using System;
using Unity.Entities;

namespace Components.Weapons
{
    [Serializable]
    public struct Firing : IComponentData
    {
        public Entity bulletPrefab;
        public float firedAt;
    }
}