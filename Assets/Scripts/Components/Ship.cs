using System;
using Components;
using UnityEngine;

[Serializable]
public class Ship : MonoBehaviour
{
    public float Speed;
    public float TiltAngle;
    public ThrusterComponent[] Thrusters;
}