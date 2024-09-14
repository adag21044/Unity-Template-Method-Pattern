using UnityEngine;

public class RightCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.right; 
    }
}
