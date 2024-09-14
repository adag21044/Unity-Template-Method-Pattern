using UnityEngine;

public abstract class CubeMover : MonoBehaviour
{
    // Template Method: Hareketin ana şablonunu tanımlar
    public void MoveCube()
    {
        Vector3 direction = GetDirection();
        MoveInDirection(direction);
    }

    // Alt sınıfların hangi yönde hareket edeceğini belirtmesi gerekiyor
    protected abstract Vector3 GetDirection();

    // Ortak hareket mantığı: Her alt sınıf yönü belirledikten sonra bu metot kullanılır
    protected void MoveInDirection(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * 5); // Hareket hızı
    }
}
