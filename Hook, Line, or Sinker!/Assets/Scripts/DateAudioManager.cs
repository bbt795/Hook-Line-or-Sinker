using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateAudioManager : MonoBehaviour
{
    public string sceneTitle;
    public string sceneTitle2;
    public AudioSource source;
    public AudioClip[] audioClipArray;
    public GameObject gameManager;
    public List<string> fishList;
    public string fishDate;
    public bool dateStart = false;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("DateGameMusic");
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        fishList = gameManager.GetComponent<DoNotDestroy>().fishList;
        fishDate = gameManager.GetComponent<DoNotDestroy>().fishDate;
 
        if(musicObj.Length > 1)
        {

            Destroy(this.gameObject);

        }
        source.volume = 0.15f;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {

        source = this.gameObject.GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == sceneTitle)
        {

            source.Pause();

        }
        else if (SceneManager.GetActiveScene().name == sceneTitle2 && !dateStart)
        {

            gameManager = GameObject.FindGameObjectWithTag("GameController");
            fishList = gameManager.GetComponent<DoNotDestroy>().fishList;
            fishDate = gameManager.GetComponent<DoNotDestroy>().fishDate;

            if (fishDate.StartsWith("Squid"))
            {
                source.clip = audioClipArray[0];
                source.volume = 0.15f;
                dateStart = true;
                source.PlayOneShot(source.clip);

            }
            else if (fishDate.StartsWith("BasicFish"))
            {
                source.clip = audioClipArray[1];
                source.volume = 0.15f;
                dateStart = true;
                source.PlayOneShot(source.clip);
            }
            else if (fishDate.StartsWith("Swordfish"))
            {
                source.clip = audioClipArray[2];
                source.volume = 0.15f;
                dateStart = true;
                source.PlayOneShot(source.clip);

            }
        }

    }
}
