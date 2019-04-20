using Components.Weapons;
using Unity.Entities;
using UnityEngine;

namespace Components.Proxies.Weapons
{
    public class BulletProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float lifeTime;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new Bullet{lifeTime = lifeTime};
            dstManager.AddComponentData(entity, data);
        }
    }
}