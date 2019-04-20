using System;
using Unity.Entities;
using UnityEngine;

namespace Components.Weapons
{
    [Serializable]
    public struct Weapon : IComponentData
    {
        public Entity bulletPrefab;
        public float fireSpeed;
        public float fireRate;
        public float bulletLifeTime;
        public float range;
    }
}