using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateImageChange : MonoBehaviour
{
    public GameObject gameManager;
    public string fishDateName;

    public Sprite[] backgrounds;
    
    public Image dateBG;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        fishDateName = gameManager.GetComponent<DoNotDestroy>().fishDate;

        //canvas = GameObject.Find("Canvas").GetComponent<Canvas>().transform.GetChild(0);
        //dateImage = transform.GetChild(2).GetComponent<Image>();

        //dateBG = GameObject.Find("Panel").GetComponent<Image>(); //.sprite = backgrounds[currentSprite];

        dateBG = GetComponent<Image>();

        if (fishDateName.StartsWith("BasicFish"))
        {
            dateBG.sprite = backgrounds[0];
        }
        else if (fishDateName.StartsWith("Squid"))
        {
            dateBG.sprite = backgrounds[1];
        }
        else if (fishDateName.StartsWith("Swordfish"))
        {
            dateBG.sprite = backgrounds[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
