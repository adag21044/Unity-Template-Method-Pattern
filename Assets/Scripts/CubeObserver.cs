using UnityEngine;

public class CubeObserver : MonoBehaviour
{
    public void Notify(string moveraType)
    {
        Debug.Log($"{moveraType}");
    }
}