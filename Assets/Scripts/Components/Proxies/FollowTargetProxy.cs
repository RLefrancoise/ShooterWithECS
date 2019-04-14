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
                TargetPosition = target ? new float3(target.position) : new float3(),
                TargetRotation = target ? quaternion.Euler(target.rotation.eulerAngles) : quaternion.identity,
                FreezeX = freezeX,
                FreezeY = freezeY,
                FreezeZ = freezeZ,
                Offset = new float3(offset)
            };
            
            dstManager.AddComponentData(entity, data);
        }
    }
}