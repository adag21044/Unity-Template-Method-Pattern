using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    public CubeMover CreateMover(string type, GameObject cubeObject)
    {
        CubeMover mover = null;

        switch(type)
        {
            case "Forward":
                mover = cubeObject.AddComponent<ForwardCubeMover>();
                break;
            case "Backward":
                mover = cubeObject.AddComponent<BackwardCubeMover>();
                break;
            default:
                Debug.LogError("Invalid type of specified");
                break;    
        }

        return mover;
    }
}