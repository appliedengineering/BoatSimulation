using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragForce : DynamicForce
{

    public override void ResolveForce(Body2D body)
    {
        // DRAG FORMULA
        // F_D = (1/2) * p * v^2 * C_d * A
        // UNITS:
        // p kg/m^3
        // v m/s^2
        // C_d unitless
        // A m^2

        // TODO: fix
        // simple fake drag
        QuantizedForce forceSum = ForceUtil.GetForceSum(body.forces);
        resolvedForce = - body.velocity;
    }
}
