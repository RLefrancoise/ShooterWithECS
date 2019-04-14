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
            var data = new Ship{Life = life, Power = power, Speed = speed, TiltAngle = tiltAngle};
            dstManager.AddComponentData(entity, data);
        }
    }
}