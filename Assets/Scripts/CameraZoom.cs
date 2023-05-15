using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1f;
    public float MinPositionZ = 1f;
    public float MaxPositionZ = 10f;

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.z < MaxPositionZ)
        {
            transform.position += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * transform.forward;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.z > MinPositionZ)
        {
            transform.position += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * transform.forward;
        }
    }
}
