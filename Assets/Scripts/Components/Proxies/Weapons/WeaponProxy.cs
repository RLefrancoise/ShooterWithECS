using System.Collections.Generic;
using Components.Weapons;
using Unity.Entities;
using UnityEngine;

namespace Components.Proxies.Weapons
{
    [RequiresEntityConversion]
    public class WeaponProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
    {
        public GameObject bulletPrefab;
        public float fireSpeed;
        public float fireRate;
        public float bulletLifeTime;
        public float range;
        
        /// <inheritdoc />
        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(bulletPrefab);
        }

        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new Weapon
            {
                bulletPrefab = conversionSystem.GetPrimaryEntity(bulletPrefab),
                fireSpeed = fireSpeed,
                fireRate = fireRate,
                bulletLifeTime = bulletLifeTime,
                range = range
            };
            dstManager.AddComponentData(entity, data);
        }
    }
}