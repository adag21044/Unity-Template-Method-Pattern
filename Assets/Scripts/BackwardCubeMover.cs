using UnityEngine;

public class BackwardCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.back; 
    }
}
