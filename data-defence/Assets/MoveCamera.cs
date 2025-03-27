using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform cameraPosition;
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
