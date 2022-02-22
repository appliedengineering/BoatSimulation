using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeForce : DynamicForce
{
    private Vector3 directionVector;
    private Quaternion forceRotation;

    public RelativeForce(Vector3 position, Vector3 directionVector, Quaternion forceRotation)
    {
        this.position = position;
        this.directionVector = directionVector;
        this.forceRotation = forceRotation;
    }

    public override void ResolveForce(Body2D body)
    {
        // the direction of the force should be relative to the boat

        // caculate torque
        float leverLength = (body.centerOfGravity - position).magnitude;

        // calculate angle of the force (actually, turns out this is not needed since we can use dot product)
        float angle = Quaternion.Angle(body.rotation, forceRotation);
        
        angle = Vector3.Dot(body.rotation.normalized * Vector3.right, directionVector);

        // note: if rudder points right, angle is negative
        // if rudder points left, angle is positive
        bool isRight = false;
        if(angle < 0)
        {
            isRight = true;
        }

        Debug.Log("angle: " + Mathf.Abs(angle) + (isRight ? " right" : " left"));

        // angle ranges from 0-1
        // 0 = straight forward, no torque
        // 1 = 100% torque

        resolvedAngularForce = Vector3.up * angle;
        resolvedForce = Vector3.right * Mathf.Sqrt(1 - Mathf.Pow(angle, 2));

    }
}
