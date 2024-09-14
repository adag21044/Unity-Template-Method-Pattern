using UnityEngine;

public class MovementObserver : MonoBehaviour
{
    public void NotifyMovement(string direction)
    {
        Debug.Log($"Cube moved in direction: {direction}");
    }
}
