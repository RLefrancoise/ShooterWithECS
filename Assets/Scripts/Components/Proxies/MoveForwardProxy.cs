using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class MoveForwardProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new MoveForward();
            dstManager.AddSharedComponentData(entity, data);
        }
    }
}