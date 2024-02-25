using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TinderScript : MonoBehaviour
{

    public GameObject profilePanel;
    public GameObject gameManager;
    public List<string> fishList;
    public string fishDate;

    Dictionary<string, Sprite> spriteMap = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {

        Sprite basicFish1 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/BasicFish1");
        Sprite basicFish2 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/BasicFish2");
        Sprite basicFish3 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/BasicFish3");

        Sprite squid1 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/Squid1");
        Sprite squid2 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/Squid2");
        Sprite squid3 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/Squid3");

        Sprite swordfish1 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/Swordfish1");
        Sprite swordfish2 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/Swordfish2");
        Sprite swordfish3 = Resources.Load<Sprite>("Sprites/Fin-der Profiles/Swordfish3");

        spriteMap.Add("BasicFish1", basicFish1);
        spriteMap.Add("BasicFish2", basicFish2);
        spriteMap.Add("BasicFish3", basicFish3);
        spriteMap.Add("Squid1", squid1);
        spriteMap.Add("Squid2", squid2);
        spriteMap.Add("Squid3", squid3);
        spriteMap.Add("Swordfish1", swordfish1);
        spriteMap.Add("Swordfish2", swordfish2);
        spriteMap.Add("Swordfish3", swordfish3);

        gameManager = GameObject.FindGameObjectWithTag("GameController");
        fishList = gameManager.GetComponent<DoNotDestroy>().fishList;
        fishDate = gameManager.GetComponent<DoNotDestroy>().fishDate;

        profilePanel.GetComponent<Image>().sprite = spriteMap[fishList[0]];

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void SwipeLeft()
    {

        fishList.RemoveAt(0);
        profilePanel.GetComponent<Image>().sprite = spriteMap[fishList[0]];

    }

    public void SwipeRight()
    {
        if (fishList[0].StartsWith("Squid") && Random.value >= 0.5)
        {

            fishDate = fishList[0];
            fishList.Clear();
            SceneManager.LoadScene("DatingGame");

        }else if (fishList[0].StartsWith("BasicFish") && Random.value <= 0.25)
        {

            fishDate = fishList[0];
            fishList.Clear();
            SceneManager.LoadScene("DatingGame");

        } else if (fishList[0].StartsWith("Swordfish") && Random.value >= 0.25)
        {

            fishDate = fishList[0];
            fishList.Clear();
            SceneManager.LoadScene("DatingGame");

        }

    }

    public void SwipeDown()
    {

        fishList.Clear();
        SceneManager.LoadScene("FishingGame");

    }
}
