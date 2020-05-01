using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Boss_Cinematic : MonoBehaviour
{
    public float Fov;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        CameraController.ChangeCameraFOV(Fov);

    }

    // Update is called once per frame
    void Update()
    {
        while (timer != 0f) {
            timer -= 1f;
        }
        CameraController.ChangeCameraFOV(Fov + 2);
    }
}
