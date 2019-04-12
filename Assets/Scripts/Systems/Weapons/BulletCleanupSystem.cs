using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    /*public class BulletCleanupSystem : JobComponentSystem
    {
        private struct BulletCleanupJob : IJobParallelFor
        {
            [ReadOnly] public EntityArray Entities;
            public ComponentDataArray<Bullet> Bullets;
            public float DeltaTime;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;

            public void Execute(int index)
            {
                var bullet = Bullets[index];
                bullet.LifeTime -= DeltaTime;
                Bullets[index] = bullet;

                if(Bullets[index].LifeTime <= 0f) EntityCommandBuffer.DestroyEntity(index, Entities[index]);
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new BulletCleanupJob
            {
                Entities = _data.Entities,
                Bullets = _data.Bullets,
                DeltaTime = Time.deltaTime,
                EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent()
            }.Schedule(_data.Length, 64, inputDeps);
        }

        private struct Data
        {
            public readonly int Length;
            public EntityArray Entities;
            public ComponentDataArray<Bullet> Bullets;
        }

        [Inject] private Data _data;
        [Inject] private BulletCleanupBarrier _barrier;
    }

    public class BulletCleanupBarrier : BarrierSystem
    {
    }*/
}
