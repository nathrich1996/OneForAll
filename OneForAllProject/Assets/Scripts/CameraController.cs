using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraController
{
   public static void ChangeCameraFOV(float fov)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = fov; ;
    }
}
