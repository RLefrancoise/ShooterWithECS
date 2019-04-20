using Components.Weapons;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class BulletCleanupSystem : JobComponentSystem
    {
        private struct BulletCleanupJob : IJobForEachWithEntity<Bullet>
        {
            public float DeltaTime;
            [ReadOnly] public EntityCommandBuffer EntityCommandBuffer;

            /// <inheritdoc />
            public void Execute(Entity entity, int index, ref Bullet bullet)
            {
                bullet.lifeTime -= DeltaTime;
                if(bullet.lifeTime <= 0f) EntityCommandBuffer.DestroyEntity(entity);
            }
        }

        private BeginInitializationEntityCommandBufferSystem _entityCommandBufferSystem;
        
        protected override void OnCreateManager()
        {
            _entityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new BulletCleanupJob
            {
                DeltaTime = Time.deltaTime,
                EntityCommandBuffer = _entityCommandBufferSystem.CreateCommandBuffer()
            }.Schedule(this, inputDeps);
            
            _entityCommandBufferSystem.AddJobHandleForProducer(job);
            return job;
        }
    }
}
