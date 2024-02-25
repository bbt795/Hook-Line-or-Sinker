using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Text;


public class DatingDialogueInt : MonoBehaviour
{
    public GameObject gameManager;
    public string fishDateName;
    public string endScene;
    public TextMeshProUGUI fishDialogueText;
    public bool startOptions = true;
    public bool endOptions = false;
    public int currentDialogue = 2;
    public int currentQuestion = 0;
    public int choiceIndex1;
    public int choiceIndex2;
    public int choiceIndex3;
    public int choiceIndex4;
    public DialogueAsset questions;
    public DialogueAsset responses;
    public DialogueAsset player;
    //All Dialogue panels
    public GameObject fishDialogue;
    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;
    //List of Option panels
    List<GameObject> options = new List<GameObject>();
    List<int> choiceIndices = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        fishDateName = gameManager.GetComponent<DoNotDestroy>().fishDate;
        fishDialogueText = fishDialogue.transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        options.Add(Option1);
        options.Add(Option2);
        options.Add(Option3);
        options.Add(Option4);

        choiceIndices.Add(choiceIndex1);
        choiceIndices.Add(choiceIndex2);
        choiceIndices.Add(choiceIndex3);
        choiceIndices.Add(choiceIndex4);

        DialogueAsset basicFishQuestions = Resources.Load<DialogueAsset>("Dialogue/BasicBitchQuestions");
        DialogueAsset basicFishResponses = Resources.Load<DialogueAsset>("Dialogue/BasicBitchResponses");
        DialogueAsset basicFishPlayer = Resources.Load<DialogueAsset>("Dialogue/BasicBitchPlayer");

        DialogueAsset eccentricSquidQuestions = Resources.Load<DialogueAsset>("Dialogue/EccentricSquidQuestions");
        DialogueAsset eccentricSquidResponses = Resources.Load<DialogueAsset>("Dialogue/EccentricSquidResponses");
        DialogueAsset eccentricSquidPlayer = Resources.Load<DialogueAsset>("Dialogue/EccentricSquidPlayer");

        DialogueAsset swordfishQuestions = Resources.Load<DialogueAsset>("Dialogue/SwordfishQuestions");
        DialogueAsset swordfishResponses = Resources.Load<DialogueAsset>("Dialogue/SwordfishResponses");
        DialogueAsset swordfishPlayer = Resources.Load<DialogueAsset>("Dialogue/SwordfishPlayer");
        
        if(fishDateName.StartsWith("BasicFish"))
        {
            fishDateName = "Basic Fish";
            questions = basicFishQuestions;
            responses = basicFishResponses;
            player = basicFishPlayer;
            StartDialogue();
        }
        else if(fishDateName.StartsWith("Squid"))
        {
            fishDateName = "Squid";
            questions = eccentricSquidQuestions;
            responses = eccentricSquidResponses;
            player = eccentricSquidPlayer;
            StartDialogue();
        }
        else if(fishDateName.StartsWith("Swordfish"))
        {
            fishDateName = "Swordfish";
            questions = swordfishQuestions;
            responses = swordfishResponses;
            player = swordfishPlayer;
            StartDialogue();
        }
        
    }

    public void StartDialogue()
    {
        TextMeshProUGUI fishNameText = fishDialogue.transform.Find("DialogueName").GetComponent<TextMeshProUGUI>();
        fishNameText.text = fishDateName;

        fishDialogueText.text = questions.dialogue[0];

        TextMeshProUGUI option1Text = Option1.GetComponentInChildren<TextMeshProUGUI>(false);
        TextMeshProUGUI option2Text = Option2.GetComponentInChildren<TextMeshProUGUI>(false);
        option1Text.text = player.dialogue[0];
        option2Text.text = player.dialogue[1];

        Option3.gameObject.SetActive(false);
        Option4.gameObject.SetActive(false);

    }
    public void InBetweenDialogue(int response)
    {
        TextMeshProUGUI optionText = Option1.GetComponentInChildren<TextMeshProUGUI>(false);
        optionText.text = "Continue";
        fishDialogueText.text = responses.dialogue[response];
        Option2.gameObject.SetActive(false);
        Option3.gameObject.SetActive(false);
        Option4.gameObject.SetActive(false);
        if(currentQuestion == 3)
        {
            endOptions = true;
        }

    }
    public void OnClickOption1()
    {
        TextMeshProUGUI optionInitialText = Option1.GetComponentInChildren<TextMeshProUGUI>(false);
        if(optionInitialText.text == "Continue" || startOptions)
        {
            if(startOptions)
            {
                startOptions = false;  
            }
            if(!endOptions)
            {
                foreach(GameObject option in options)
                {
                    if(!option.gameObject.activeSelf)
                    {
                        option.SetActive(true);
                    }
                    TextMeshProUGUI optionText = option.GetComponentInChildren<TextMeshProUGUI>(false);
                    optionText.text = player.dialogue[currentDialogue];
                    currentDialogue++;
                }
            }
            else
            {
                DateEnd();
            }  
            currentQuestion++;
            fishDialogueText.text = questions.dialogue[currentQuestion];
        }
        else
        {
            CheckAffinity(currentDialogue - 5);
            InBetweenDialogue(currentDialogue - 5);  
        }
        

    }

    public void OnClickOption2()
    {
        if(startOptions)
        {
            gameManager.GetComponent<DoNotDestroy>().affinity = -10;
            DateEnd();
        }
        else
        {
            CheckAffinity(currentDialogue - 4);
            InBetweenDialogue(currentDialogue - 4);
        }
        
    }

    public void OnClickOption3()
    {
        CheckAffinity(currentDialogue - 3);
        InBetweenDialogue(currentDialogue - 3);        
    }

    public void OnClickOption4()
    {
        CheckAffinity(currentDialogue - 2);
        InBetweenDialogue(currentDialogue - 2);
    }

    public void CheckAffinity(int num)
    {
        if(fishDateName == "Basic Fish")
        {
            if(num == 6)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity -= 10;
            }
            else if(num == 2 || num == 8 || num == 10)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity += 5;
            }
            else if(num == 3 || num == 12)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity -= 5;
            }
        }
        else if(fishDateName == "Squid")
        {
            if(num == 5 || num == 7 || num == 13)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity += 5;
            }
            else if(num == 3 || num == 9 || num == 11)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity -= 5;
            }
        }
        else if(fishDateName == "Swordfish")
        {
            if(num == 5 || num == 8 || num == 10)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity += 5;
            }
            else if(num == 3 || num == 7 || num == 11)
            {
                gameManager.GetComponent<DoNotDestroy>().affinity -= 5;
            }
        }
        if(gameManager.GetComponent<DoNotDestroy>().affinity == -10 || endOptions)
        {
            DateEnd();
        }
        //Add dialogue change based on option number?
        //fishDialogueText.text = responses.dialogue[];

    }

    public IEnumerator EndCoroutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(endScene);
    }

    public void DateEnd()
    {
        int affinity = gameManager.GetComponent<DoNotDestroy>().affinity;
        Option1.gameObject.SetActive(false);
        Option2.gameObject.SetActive(false);
        Option3.gameObject.SetActive(false);
        Option4.gameObject.SetActive(false);

        if(affinity == 15 && endOptions)
        {
            fishDialogueText.text = responses.dialogue[13];
        }
        else if(affinity == -10 && !endOptions)
        {
            fishDialogueText.text = responses.dialogue[0];
        }
        else if(affinity < 0 && affinity >= -10 && endOptions)
        {
            fishDialogueText.text = responses.dialogue[15];
        }
        else if(affinity > 0 && affinity < 15 && endOptions)
        {
            fishDialogueText.text = responses.dialogue[14];
        }
        StartCoroutine(EndCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
