using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSLEVEL : MonoBehaviour
{
    public float bgSpeed, bldgTimer, maxTimer;
    public Renderer bgRend;
    public Transform skySpawn;
    public GameObject skyscraper;
    public Sprite[] skyss;
    private SpriteRenderer rend;
    private Sprite cur;
    private int roll;
    private float position;

    void Start()
    {
        rend = skyscraper.GetComponent<SpriteRenderer>();
        maxTimer = 3;
        bldgTimer = maxTimer;
    }

    void Update()
    {
        roll = Random.Range(0, 2);
        cur = skyss[roll];
        rend.sprite = cur;
        bldgTimer -= Time.deltaTime;
        if (bldgTimer <= 0)
        {
            Instantiate(skyscraper, skySpawn);
            bldgTimer = maxTimer;
        }
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
    
}
