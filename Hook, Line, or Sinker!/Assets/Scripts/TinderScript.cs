using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        Sprite basicFish1 = Resources.Load<Sprite>("Fin-derProfiles/BasicFish1");
        Sprite basicFish2 = Resources.Load<Sprite>("Fin-derProfiles/BasicFish2");
        Sprite basicFish3 = Resources.Load<Sprite>("Fin-derProfiles/BasicFish3");

        Sprite squid1 = Resources.Load<Sprite>("Fin-derProfiles/Squid1");
        Sprite squid2 = Resources.Load<Sprite>("Fin-derProfiles/Squid2");
        Sprite squid3 = Resources.Load<Sprite>("Fin-derProfiles/Squid3");

        Sprite swordfish1 = Resources.Load<Sprite>("Fin-derProfiles/Swordfish1");
        Sprite swordfish2 = Resources.Load<Sprite>("Fin-derProfiles/Swordfish2");
        Sprite swordfish3 = Resources.Load<Sprite>("Fin-derProfiles/Swordfish3");

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

        Debug.Log(fishList[0]);

        if(basicFish1 == null)
        {

            Debug.Log("Yup");

        }

        profilePanel.GetComponent<Image>().sprite = spriteMap[fishList[0]];

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void SwipeLeft()
    {

        if (fishList.Count == 1)
        {

            fishList.Clear();
            profilePanel.SetActive(false);
            return;

        }

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

        } else
        {

            if(fishList.Count == 1)
            {

                fishList.Clear();
                profilePanel.SetActive(false);
                return;

            }

            fishList.RemoveAt(0);
            profilePanel.GetComponent<Image>().sprite = spriteMap[fishList[0]];

        }

    }

    public void SwipeDown()
    {

        Debug.Log("Swiped Down");
        fishList.Clear();
        SceneManager.LoadScene("FishingGame");
        

    }
}
