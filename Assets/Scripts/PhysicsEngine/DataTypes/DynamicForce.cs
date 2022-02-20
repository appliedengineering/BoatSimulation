using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicForce : QuantizedForce
{
    public Vector3 resolvedForce { get; set; }
    public Vector3 resolvedAngularForce { get; set; }


    

    // creates a dynamic force by incorparating elements of Body2D
    public virtual void ResolveForce(Body2D body)
    {
        
    }
}