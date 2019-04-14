using System;
using Unity.Entities;
using UnityEngine;

namespace Components.Weapons
{
    [Serializable]
    public struct Weapon : IComponentData
    {
        public Entity BulletPrefab;
        public float FireSpeed;
        public float FireRate;
        public float BulletLifeTime;
        public float Range;
    }
}