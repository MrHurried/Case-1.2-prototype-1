using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatMathf
{
    public static Quaternion RotationClampQuaternion(Vector3 eulers)
    {
        eulers = RotationClampVec3(eulers);

        return Quaternion.Euler(eulers);
    }

    public static Vector3 RotationClampVec3(Vector3 eulers)
    {
        eulers.x = RotationClampFloat(eulers.x);
        eulers.y = RotationClampFloat(eulers.y);
        eulers.z = RotationClampFloat(eulers.z);

        return eulers;
    }

    public static Vector3 RotationClampVec3(float x, float y, float z)
    {
        x = RotationClampFloat(x);
        y = RotationClampFloat(y);
        z = RotationClampFloat(z);

        return new Vector3(x, y, z);
    }

    public static Quaternion RotationClampQuaternion(float x, float y, float z)
    {
        Vector3 eulers = RotationClampVec3(x, y, z);

        return Quaternion.Euler(eulers);
    }

    public static float RotationClampFloat(float val)
    {

        while (val > 360f)
        {
            val -= 360f;
        }


        while (val < 0f)
        {
            val += 360f;
        }

        return val;

    }
}
