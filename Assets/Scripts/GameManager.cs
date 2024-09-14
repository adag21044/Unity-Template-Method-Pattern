using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    private CubeFactory cubeFactory;
    private CubeObserver cubeObserver;

    void Start()
    {
        cubeFactory = gameObject.AddComponent<CubeFactory>();
        cubeObserver = gameObject.AddComponent<CubeObserver>();

        // Create two different types of cube
        GameObject forwardCube = Instantiate(cubePrefab);
        GameObject backwardCube = Instantiate(cubePrefab);

        //Create cubes and attach movers
        CubeMover forwardMover = cubeFactory.CreateMover("Forward", forwardCube);
        CubeMover backwardMover = cubeFactory.CreateMover("Backward", backwardCube);

        // Move cubes
        forwardMover.Move();
        cubeObserver.Notify("Forward");

        backwardMover.Move();
        cubeObserver.Notify("Backward"); 
    }
}