using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab; // Küp prefab referansı
    private CubeMoverFactory moverFactory;
    private MovementObserver observer;
    private CubeMover activeMover;

    void Start()
    {
        moverFactory = new CubeMoverFactory();
        observer = gameObject.AddComponent<MovementObserver>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveCube("W");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveCube("S");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveCube("A");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveCube("D");
        }
    }

    private void MoveCube(string direction)
    {
        // Önceki hareketi kaldır
        if (activeMover != null)
        {
            Destroy(activeMover);
        }

        // Yeni bir küp hareket ettirici oluştur
        activeMover = moverFactory.GetCubeMover(direction, cubePrefab);

        // Küpü hareket ettir
        if (activeMover != null)
        {
            activeMover.MoveCube();
            observer.NotifyMovement(direction);
        }
    }
}
