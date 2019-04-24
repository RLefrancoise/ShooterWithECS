using Components.Weapons;
using Unity.Entities;
using UnityEngine;

namespace Components.Proxies.Weapons
{
    public class PlayerWeaponProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddSharedComponentData(entity, new PlayerWeapon());
        }
    }
}