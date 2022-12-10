using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.parent.Rotate(Vector3.up, mouseX);
    }
}


