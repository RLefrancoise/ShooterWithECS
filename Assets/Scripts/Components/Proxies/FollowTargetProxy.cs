using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components.Proxies
{
    public class FollowTargetProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public Transform target;
        public bool freezeX;
        public bool freezeY;
        public bool freezeZ;
        public Vector3 offset;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new FollowTarget
            {
                targetPosition = target ? new float3(target.position) : new float3(),
                targetRotation = target ? quaternion.Euler(target.rotation.eulerAngles) : quaternion.identity,
                freezeX = freezeX,
                freezeY = freezeY,
                freezeZ = freezeZ,
                offset = new float3(offset)
            };
            
            dstManager.AddComponentData(entity, data);
        }
    }
}