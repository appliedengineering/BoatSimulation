using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUtil
{
    // Utility for QuantizedForce

    // CREATING FORCES
    public static QuantizedForce CreateLinearForce(Vector3 position, Vector3 force)
    {
        return new QuantizedForce(position, force);
    }


    public static DynamicForce CreateDragForce()
    {
        return new DragForce();
    }

    public static DynamicForce CreateRelativeForce(Vector3 position, Vector3 directionVector)
    {
        return new RelativeForce(position, directionVector);
    }


    // FORCES
    public static QuantizedForce GetForceSum(List<QuantizedForce> forces)
    {
        QuantizedForce forceSum = new QuantizedForce();
        foreach(QuantizedForce force in forces)
        {
            forceSum.force += force.force;
            forceSum.torque += force.torque;
        }
        return forceSum;
    }


    // ACCELERATION
    public static Vector3 GetAccelerationWithMass(Vector3 force, float mass)
    {
        Vector3 newForce = ForceUtil.GetDuplicateInstanceVector3(force);
        if (mass < 0)
        {
            newForce = Vector3.zero;
        } else
        {
            newForce /= mass; // bc F=ma
        }

        return newForce;
    }

    private static Vector3 GetDuplicateInstanceVector3(Vector3 force)
    {
        return new Vector3 (force.x, force.y, force.z);
    }


   
}
