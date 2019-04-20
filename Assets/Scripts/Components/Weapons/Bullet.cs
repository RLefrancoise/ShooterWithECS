using System;
using Unity.Entities;

namespace Components.Weapons
{
    [Serializable]
    public struct Bullet : IComponentData
    {
        public float lifeTime;
    }
}