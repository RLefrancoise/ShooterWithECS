using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine.Jobs;

namespace Systems
{
    public class FollowTargetSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct FollowTargetJob : IJobForEach<Translation, FollowTarget>
        {
            /// <inheritdoc />
            public void Execute(ref Translation translation, ref FollowTarget followTarget)
            {
                var position = followTarget.targetPosition;
                
                if (!followTarget.freezeX) position.x = followTarget.targetPosition.x;
                if (!followTarget.freezeY) position.y = followTarget.targetPosition.y;
                if (!followTarget.freezeZ) position.z = followTarget.targetPosition.z;

                translation.Value = position + followTarget.offset;
            }
        }
        
        /*protected override void OnUpdate()
        {
            Entities.ForEach((FollowTargetComponent followTarget) =>
            {
                var position = followTarget.transform.position;

                if (!followTarget.FreezeX) position.x = followTarget.Target.position.x;
                if (!followTarget.FreezeY) position.y = followTarget.Target.position.y;
                if (!followTarget.FreezeZ) position.z = followTarget.Target.position.z;

                followTarget.transform.position = position + followTarget.Offset;
            });
        }*/

        /// <inheritdoc />
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new FollowTargetJob().Schedule(this, inputDeps);
        }
    }
}
