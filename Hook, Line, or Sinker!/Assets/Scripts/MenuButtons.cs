using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject instructionsPanel;

    public void NewGame()
    {

        SceneManager.LoadScene(1);

    }

    public void Instructions()
    {

        if (mainPanel.activeSelf == true)
        {

            mainPanel.SetActive(false);

        }

        instructionsPanel.SetActive(true);

    }

    public void ExitGame()
    {

        Application.Quit();

    }

}
