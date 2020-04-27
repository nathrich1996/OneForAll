using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSLEVEL : MonoBehaviour
{
    public float bgSpeed, bldgTimer, maxTimer;
    public Renderer bgRend;
    public Transform skySpawn;
    public GameObject skyscraper;

    void Start()
    {
        maxTimer = 5;
        bldgTimer = maxTimer;
    }

    void Update()
    {
        bldgTimer -= Time.deltaTime;
        if (bldgTimer <= 0)
        {
            Instantiate(skyscraper, skySpawn);
            bldgTimer = maxTimer;
        }
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
    
}
