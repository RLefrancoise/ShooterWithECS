using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //Level
    [SerializeField]
    private Bounds _levelLimits;
    public static Bounds LevelLimits;

    private void Awake()
    {
        LevelLimits = _levelLimits;
    }
}