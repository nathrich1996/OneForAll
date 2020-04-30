using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLogos : MonoBehaviour
{
    public Image currentAbility1;
    public Image currentAbility2;
    public Image currentHead;

    public Sprite ojAbility1;
    public Sprite ojAbility2;
    public Sprite ojHead;

    public Sprite atlasAbility1;
    public Sprite atlasAbility2;
    public Sprite atlasHead;

    public Sprite calicoAbility1;
    public Sprite calicoAbility2;
    public Sprite calicoHead;
    // Start is called before the first frame update
    HeroSwap hs;
    string currentHero;
    string swappedHero;
    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroSwap>();
        currentHero = hs.GetCurrentHero();
        string swappedHero = currentHero;
    }

    // Update is called once per frame
    void Update()
    {
        currentHero = hs.GetCurrentHero();
        if (currentHero!=swappedHero)
        {
            swappedHero = currentHero;
            ChangeAbilityLogos(swappedHero);
        }
    }
    void ChangeAbilityLogos(string hero)
    {
        switch(hero)
        {
            case "Justice":
                currentAbility1.sprite = ojAbility1;
                currentAbility2.sprite = ojAbility2;
                currentHead.sprite = ojHead;
                break;
            case "Atlas":
                currentAbility1.sprite = atlasAbility1;
                currentAbility2.sprite = atlasAbility2;
                currentHead.sprite = atlasHead;
                break;
            case "Calico":
                currentAbility1.sprite = calicoAbility1;
                currentAbility2.sprite = calicoAbility2;
                currentHead.sprite = calicoHead;
                break;
            default:
                break;
        }
    }
}
