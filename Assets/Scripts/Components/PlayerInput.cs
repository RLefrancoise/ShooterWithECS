using System;
using Unity.Entities;

[Serializable]
public struct PlayerInput : IComponentData
{
	public float Horizontal;
	public float Vertical;
}
