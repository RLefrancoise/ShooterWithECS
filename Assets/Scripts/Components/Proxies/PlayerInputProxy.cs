using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class PlayerInputProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new PlayerInput();
            dstManager.AddComponentData(entity, data);
        }
    }
}