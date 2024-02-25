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
            StartDialogue(basicFishQuestions, basicFishResponses, basicFishPlayer);
        }
        else if(fishDateName.StartsWith("Squid"))
        {
            StartDialogue(eccentricSquidQuestions, eccentricSquidResponses, eccentricSquidPlayer);
        }
        else if(fishDateName.StartsWith("Swordfish"))
        {
            StartDialogue(swordfishQuestions, swordfishResponses, swordfishPlayer);
        }
        
    }

    public void StartDialogue(DialogueAsset questions, DialogueAsset responses, DialogueAsset player)
    {
        TextMeshProUGUI fishNameText = fishDialogue.transform.Find("DialogueName").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI fishDialogueText = fishDialogue.transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        fishNameText.text = fishDateName;

        fishDialogueText.text = questions.dialogue[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
