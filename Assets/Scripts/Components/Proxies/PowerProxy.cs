using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class PowerProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float value;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new Power {value = value};
            dstManager.AddComponentData(entity, data);
        }
    }
}