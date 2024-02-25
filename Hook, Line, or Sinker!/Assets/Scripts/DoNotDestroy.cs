using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{

    public List<string> fishList = new List<string>();
    public string fishDate;

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

    }
}
