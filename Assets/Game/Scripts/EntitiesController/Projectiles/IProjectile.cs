using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    public GameObjectSet TeamSet { get; set; }
    public GameObject Emitter { get; set; }
    public Vector2 Velocity { get; set; }
    public float AngularVelocity { get; set; }
}
