# Template Method Pattern in Unity

This project demonstrates the Template Method Pattern in Unity. The Template Method Pattern defines the skeleton of an algorithm in a base class but lets subclasses override specific steps of the algorithm without changing its structure. 

In this example, the project consists of a `CubeMover` base class and several derived classes that implement specific movement directions for a Unity GameObject (cube). The `GameManager` class handles user input and manages cube movement through different `CubeMover` implementations. 

## Project Structure

### 1. `CubeMover` Class
- **Location**: `CubeMover.cs`
- **Description**: Abstract base class that defines the template method `MoveCube` for moving a cube. Subclasses override the `GetDirection` method to provide specific movement directions.

```csharp
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
        transform.Translate(direction * Time.deltaTime * 5); 
    }
}
```

### 2. `BackwardCubeMover` Class
- **Location**: `BackwardCubeMover.cs`
- **Description**: Moves the cube backward.

```csharp
using UnityEngine;

public class BackwardCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.back; 
    }
}
```

### 3. `ForwardCubeMover` Class
- **Location**: `ForwardCubeMover.cs`
- **Description**: Moves the cube forward.

```csharp
using UnityEngine;

public class ForwardCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.forward; 
    }
}
```

### 4. `FLeftCubeMover` Class
- **Location**: `LeftCubeMover.cs`
- **Description**: Moves the cube to the left.

```csharp
using UnityEngine;

public class LeftCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.left; 
    }
}
```

### 5. `RightCubeMover` Class
- **Location**: `RightCubeMover.cs`
- **Description**: Moves the cube to the right.

```csharp
using UnityEngine;

public class RightCubeMover : CubeMover
{
    protected override Vector3 GetDirection()
    {
        return Vector3.right; 
    }
}
```

### 6. `CubeMoverFactory` Class
- **Location**: `CubeMoverFactory.cs`
- **Description**: Factory class to create different `CubeMover` instances based on user input.

```csharp
using UnityEngine;

public class CubeMoverFactory
{
    public CubeMover GetCubeMover(string input, GameObject cube)
    {
        CubeMover mover = null;

        switch (input)
        {
            case "W":
                mover = cube.AddComponent<ForwardCubeMover>();
                break;
            case "S":
                mover = cube.AddComponent<BackwardCubeMover>();
                break;
            case "A":
                mover = cube.AddComponent<LeftCubeMover>();
                break;
            case "D":
                mover = cube.AddComponent<RightCubeMover>();
                break;
            default:
                Debug.LogError("Invalid input");
                break;
        }

        return mover;
    }
}
```

### 7. `GameManager` Class
- **Location**: `GameManager.cs`
- **Description**: Manages user input, handles cube movement, and uses the `CubeMoverFactory` to instantiate appropriate `CubeMover` instances.

```csharp
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
```

### 8. `MovementObserver` Class
- **Location**: `MovementObserver.cs`
- **Description**: Observes and logs the movement direction of the cube.

```csharp
using UnityEngine;

public class MovementObserver : MonoBehaviour
{
    public void NotifyMovement(string direction)
    {
        Debug.Log($"Cube moved in direction: {direction}");
    }
}
```

