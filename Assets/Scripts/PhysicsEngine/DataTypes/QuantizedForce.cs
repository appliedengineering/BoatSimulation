using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantizedForce
{

    // standard SI units

    public Vector3 position { get; set; }
    public Vector3 force { get; set; } = Vector3.zero; // m/s
    public Vector3 torque { get; set; } = Vector3.zero; // deg/s


    public QuantizedForce() { }

    public QuantizedForce(Vector3 position, Vector3 force)
    {
        this.position = position;
        this.force = force;
    }

}
