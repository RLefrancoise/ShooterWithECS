using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class HealthProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float value;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new Health {value = value};
            dstManager.AddComponentData(entity, data);
        }
    }
}