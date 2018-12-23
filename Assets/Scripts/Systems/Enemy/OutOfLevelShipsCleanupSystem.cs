using Unity.Entities;
using UnityEngine;

namespace Systems.Enemy
{
    public class OutOfLevelShipsCleanupSystem : ComponentSystem
    {
        private struct Filter
        {
            public Ship Ship;
            public Transform Transform;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var position = entity.Transform.position;

                if (position.x < Bootstrap.LevelLimits.min.x ||
                    position.x > Bootstrap.LevelLimits.max.x ||
                    position.z < Bootstrap.LevelLimits.min.z ||
                    position.z > Bootstrap.LevelLimits.max.z)
                {
                    Object.Destroy(entity.Transform.gameObject);
                }
            }
        }
    }
}
