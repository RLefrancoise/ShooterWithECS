using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class ShipProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float life;
        public float power;
        public float speed;
        public float tiltAngle;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new Ship{life = life, power = power, speed = speed, tiltAngle = tiltAngle};
            dstManager.AddComponentData(entity, data);
        }
    }
}