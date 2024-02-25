using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public string sceneTitle;
    public string sceneTitle2;
    public AudioSource source;

    public AudioClip[] audioClipArray;

    public GameObject gameManager;
    public List<string> fishList;
    public string fishDate;

    public bool dateStart = false;

    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        source = this.gameObject.GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == sceneTitle && !dateStart)
        {
            source.Pause();

            gameManager = GameObject.FindGameObjectWithTag("GameController");
            fishList = gameManager.GetComponent<DoNotDestroy>().fishList;
            fishDate = gameManager.GetComponent<DoNotDestroy>().fishDate;

            if (fishDate.StartsWith("Squid"))
            {
                source.clip = audioClipArray[0];
                dateStart = true;
                source.PlayOneShot(source.clip);

            }
            else if (fishDate.StartsWith("BasicFish"))
            {

                source.clip = audioClipArray[1];
                dateStart = true;
                source.PlayOneShot(source.clip);

            }
            else if (fishDate.StartsWith("Swordfish"))
            {

                source.clip = audioClipArray[2];
                dateStart = true;
                source.PlayOneShot(source.clip);

            }
        }

        //gameManager.GetComponent<DoNotDestroy>().fishDate = fishDate;

        
    }
}
