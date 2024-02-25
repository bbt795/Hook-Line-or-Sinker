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
    public int currentDialogue = 2;
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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        fishDateName = gameManager.GetComponent<DoNotDestroy>().fishDate;
        options.Add(Option1);
        options.Add(Option2);
        options.Add(Option3);
        options.Add(Option4);

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
        TextMeshProUGUI fishDialogueText = fishDialogue.transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        fishNameText.text = fishDateName;

        fishDialogueText.text = questions.dialogue[0];

        TextMeshProUGUI option1Text = Option1.GetComponentInChildren<TextMeshProUGUI>(false);
        TextMeshProUGUI option2Text = Option2.GetComponentInChildren<TextMeshProUGUI>(false);
        option1Text.text = player.dialogue[0];
        option2Text.text = player.dialogue[1];

        Option3.gameObject.SetActive(false);
        Option4.gameObject.SetActive(false);

    }

    public void ChoiceOnClick()
    {
        ChoiceResponses();
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

    public void ChoiceResponses()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
