using UnityEngine;

public abstract class CubeMover : MonoBehaviour
{
    // Template Method: Defines a fixed algorithm structure, subclasses change certain steps 
    public void Move()
    {
        GetMovementInfo();
        MoveAlongPath();
        DebugMovement();
    }

    // Some of the workflow is fixed here
    public abstract void GetMovementInfo(); // Subclasses customize this step
    public abstract void MoveAlongPath(); // Subclasses customize this step

    // Non-overridden step
    protected virtual void DebugMovement()
    {
        Debug.Log("Moving cube");
    }
}
