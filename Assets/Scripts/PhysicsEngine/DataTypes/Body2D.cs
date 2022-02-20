using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body2D
{
    // properties
    public Vector3 velocity { get; set; } = Vector3.zero;
    public Vector3 angularVelocity { get; set; } = Vector3.zero;
    public Vector3 position {get; set;}
    public Quaternion rotation { get; set; }

    public float mass { get; set; } = 130;

    // store the forces acting on the boat (acts like a queue, forces are removed from the list every FixedUpdate)
    public List<QuantizedForce> forces { get; set; } = new List<QuantizedForce>();

    public List<DynamicForce> dynamicForces { get; set; } = new List<DynamicForce>();

    public void UpdatePosition()
    {
        ApplyForces();
        ApplyVelocities();
    }

    private void ApplyForces()
    {
        foreach (QuantizedForce qForce in forces)
        {
            if (qForce != null)
            {
                velocity += ForceUtil.GetAccelerationWithMass(qForce.force, mass);

                angularVelocity += ForceUtil.GetAccelerationWithMass(qForce.torque, mass);
            }
        }


        foreach (DynamicForce dForce in dynamicForces)
        {
            if (dForce != null)
            {
                dForce.ResolveForce(this);
                velocity += ForceUtil.GetAccelerationWithMass(dForce.resolvedForce, mass);
            }
        }

        forces.Clear(); // make sure to do this after resolving dynamics forces first
        dynamicForces.Clear();
    }

    private void ApplyVelocities()
    {
        position += velocity;
        rotation *= Quaternion.Euler(angularVelocity);
    }


}
