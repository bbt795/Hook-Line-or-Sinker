using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public string sceneTitle;
    public string sceneTitle2;
    public AudioSource source;
    public bool gameRestart = false;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
 
        if(musicObj.Length > 1)
        {

            Destroy(this.gameObject);

        }
        source.volume = 0.15f;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {


    }
}
