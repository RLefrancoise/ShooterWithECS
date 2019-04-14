using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class MovementDataProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new MovementData();
            dstManager.AddComponentData(entity, data);
        }
    }
}