using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{

    public List<string> fishList = new List<string>();
    public string fishDate;
    public int fishCount = 0;
    public int squidCount = 0;
    public int swordCount = 0;
    public int affinity;


    private void Awake(){
        GameObject[] gameManagerObj = GameObject.FindGameObjectsWithTag("GameController");

        if (gameManagerObj.Length > 1)
        {

            Destroy(this.gameObject);

        }

        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        while(fishCount > 0)
        {

            fishList.Add("BasicFish" + Random.Range(1,4));
            fishCount--;

        }

        while(squidCount > 0)
        {

            fishList.Add("Squid" + Random.Range(1, 4));
            squidCount--;

        }

        while(swordCount > 0)
        {

            fishList.Add("Swordfish" + Random.Range(1, 4));
            swordCount--;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Destroy(this.gameObject);

            SceneManager.LoadScene("MainMenu");

        }

    }
}
