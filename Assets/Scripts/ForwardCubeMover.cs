using UnityEngine;

public class ForwardCubeMover : CubeMover
{
    public override void GetMovementInfo()
    {
        Debug.Log("Getting movement info for forward cube");
    }

    public override void MoveAlongPath()
    {
        Debug.Log("Moving forward cube along path");
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }
}
    
