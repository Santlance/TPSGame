using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mainCamera;
    public Camera orbitCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        orbitCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mainCamera.enabled = false;
            orbitCamera.enabled = true;
        }
    }
}
