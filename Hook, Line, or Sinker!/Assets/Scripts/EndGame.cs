using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject gameManager;
    private int fishAffinity;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("GameController");
        fishAffinity = gameManager.GetComponent<DoNotDestroy>().affinity;

        if(fishAffinity == 15)
        {

            Sprite goodEnding = Resources.Load<Sprite>("GameOver/GoodEnding");
            gameOverPanel.GetComponent<Image>().sprite = goodEnding;

        } else if(fishAffinity < 15 && fishAffinity >= 0)
        {

            Sprite normalEnding = Resources.Load<Sprite>("GameOver/NormalEnding");
            gameOverPanel.GetComponent<Image>().sprite = normalEnding;

        } else if(fishAffinity < 0)
        {

            Sprite badEnding = Resources.Load<Sprite>("GameOver/BadEnding");
            gameOverPanel.GetComponent<Image>().sprite = badEnding;

        }

    }

    public void RetryButton()
    {

        Debug.Log(fishAffinity);
        gameManager.GetComponent<DoNotDestroy>().affinity = 0;
        SceneManager.LoadScene("FishingGame");

    }

    public void QuitButton()
    {

        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
