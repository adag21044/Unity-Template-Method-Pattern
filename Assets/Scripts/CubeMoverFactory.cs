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
