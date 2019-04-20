using Unity.Entities;
using UnityEngine;

namespace Components.Proxies
{
    public class LookAtTargetProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public LookAtTarget.Axis lookAtAxis;
        public bool keepWorldUp;
        public Transform target;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new LookAtTarget{lookAtAxis = lookAtAxis, keepWorldUp = keepWorldUp, targetWorldPosition = target.position};
            dstManager.AddComponentData(entity, data);
        }
    }
}