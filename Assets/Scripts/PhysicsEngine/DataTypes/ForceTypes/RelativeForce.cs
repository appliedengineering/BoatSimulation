using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeForce : DynamicForce
{
    private Vector3 directionVector;

    public RelativeForce(Vector3 position, Vector3 directionVector)
    {
        this.position = position;
        this.directionVector = directionVector;
    }

    public override void ResolveForce(Body2D body)
    {
        
    }
}
