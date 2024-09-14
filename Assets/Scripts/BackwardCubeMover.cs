using UnityEngine;

public class BackwardCubeMover : CubeMover
{
    public override void GetMovementInfo()
    {
        Debug.Log("Moving backward");
    }

    public override void MoveAlongPath()
    {
        Debug.Log("Moving backward cube along path");
        transform.Translate(Vector3.back * Time.deltaTime * 5);
    }
}