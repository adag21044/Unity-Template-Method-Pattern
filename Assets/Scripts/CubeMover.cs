using UnityEngine;

public abstract class CubeMover : MonoBehaviour
{
    // Template Method
    public void MoveCube()
    {
        Vector3 direction = GetDirection();
        MoveInDirection(direction);
    }

    
    protected abstract Vector3 GetDirection();

    
    protected void MoveInDirection(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * 5); // Hareket hızı
    }
}
