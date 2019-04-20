using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components.Proxies
{
    public class ThrusterProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public Color minColour;
        public float maxPower;
        
        /// <inheritdoc />
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new Thruster
            {
                isInitialized = false,
                originalStartSize = 0f,
                originalLifeTime = 0f,
                originalStartColor = float4.zero,
                minColour = minColour.ToFloat4(),
                power = 0f,
                maxPower = maxPower
            };
            dstManager.AddComponentData(entity, data);
        }
    }
}