using UnityEngine;
using UnityEngine.XR;

public class XRFieldOfViewController : MonoBehaviour
{
    private Camera xrCamera;

    void Start()
    {
        // Try to find the main camera under XR Origin
        xrCamera = Camera.main;

        if (xrCamera == null)
        {
            Debug.LogError("XR Camera not found. Make sure your main XR camera has the 'MainCamera' tag.");
        }
    }

    void Update()
    {
        if (xrCamera == null) return;

        if (Input.GetKeyDown(KeyCode.J))
        {
            SetFieldOfView(45f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SetFieldOfView(60f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            SetFieldOfView(90f);
        }
    }

    private void SetFieldOfView(float fov)
    {
        xrCamera.fieldOfView = fov;
        Debug.Log("FOV set to " + fov);
    }
}
