using System;
using UnityEngine;

[Serializable]
public class Ship : MonoBehaviour
{
    public float Speed;
    public bool Fire;
    public float TimeBetweenFire;
    public float LastFireTime;
}