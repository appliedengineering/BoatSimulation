using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorUtil 
{
    // Utility class for vectors

    // this method is informal, you don't really square vectors
    // returns a vec3(x^2, y^2, z^2)
    public static Vector3 SquareVectorPreserveDirection(Vector3 vector)
    {
        return new Vector3(SquareButPreserveNegative(vector.x), SquareButPreserveNegative(vector.y), SquareButPreserveNegative(vector.z));
    }

    private static float SquareButPreserveNegative(float x)
    {
        if(x < 0)
        {
            return -Mathf.Pow(x, 2);
        }
        return Mathf.Pow(x, 2);
    }
}
