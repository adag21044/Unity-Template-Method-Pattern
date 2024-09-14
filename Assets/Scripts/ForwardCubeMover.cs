using UnityEngine;

public class ForwardCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.forward; // İleri yön
    }
}
