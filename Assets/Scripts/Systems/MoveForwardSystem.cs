using Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class MoveForwardSystem : JobComponentSystem
    {
        private struct MoveForwardJob : IJobForEach<Translation, Rotation, MoveSpeed>
        {
            public float DeltaTime;
            
            /// <inheritdoc />
            public void Execute(ref Translation translation, ref Rotation rotation, ref MoveSpeed moveSpeed)
            {
                translation.Value = translation.Value + moveSpeed.value * math.forward(rotation.Value) * DeltaTime;
            }
        }
        
        /*protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform, MoveForward moveForward, MoveSpeed moveSpeed) =>
                {
                    transform.position = transform.position + moveSpeed.Speed * transform.forward * Time.deltaTime;
                });
        }*/
        
        /// <inheritdoc />
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new MoveForwardJob
            {
                DeltaTime = Time.deltaTime
            }.Schedule(this, inputDeps);
        }
    }
}