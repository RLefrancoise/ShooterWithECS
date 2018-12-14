using Unity.Entities;

namespace Systems
{
    public class FollowTargetSystem : ComponentSystem
    {
        private struct Filter
        {
            public FollowTargetComponent FollowTarget;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var position = entity.FollowTarget.transform.position;

                if (!entity.FollowTarget.FreezeX) position.x = entity.FollowTarget.Target.position.x;
                if (!entity.FollowTarget.FreezeY) position.y = entity.FollowTarget.Target.position.y;
                if (!entity.FollowTarget.FreezeZ) position.z = entity.FollowTarget.Target.position.z;

                entity.FollowTarget.transform.position = position + entity.FollowTarget.Offset;
            }
        }
    }
}
