using UnityEngine;

public class LeftCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.left; 
    }
}
