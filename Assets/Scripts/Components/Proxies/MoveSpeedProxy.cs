using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class MoveSpeedProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float value;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new MoveSpeed{value = value};
            dstManager.AddComponentData(entity, data);
        }
    }
}