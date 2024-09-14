using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cube; 
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
        if (Input.GetKey(KeyCode.W))
        {
            MoveCube("W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveCube("S");
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveCube("A");
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveCube("D");
        }
        else
        {
            StopCube();
        }
    }

    private void MoveCube(string direction)
    {
        
        if (activeMover != null)
        {
            Destroy(activeMover);
        }

        
        activeMover = moverFactory.GetCubeMover(direction, cube);

        
        if (activeMover != null)
        {
            activeMover.MoveCube();
            observer.NotifyMovement(direction);
        }
    }

    private void StopCube()
    {
        if (activeMover != null)
        {
            Destroy(activeMover); 
        }
    }
}
