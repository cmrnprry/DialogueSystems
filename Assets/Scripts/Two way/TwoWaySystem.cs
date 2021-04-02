using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // NEED TO IMPORT THIS TO USE UNITY UI
using TMPro; //NEED TO IMPORT THIS TO USE TMPRO


public class TwoWaySystem : MonoBehaviour
{
    public GameObject textbox; //Text box that will be the parent
    public Animator box;
    public TextMeshProUGUI text; //Text Gameobject that  will hold the text
    public TextMeshProUGUI speakerTag; //speaker text Gameobject that  will hold the text

    private Dialogue[] dialogue; //array of dialogue
    private int index = 1; //What line of dialogue we're on
    private bool isPlayingDialogue = false; //check if we should be playing dialogue
    private string lastTalk = "";

    // Start is called before the first frame update
    void Start()
    {
        // Clear the text and turn off the textbox
        text.text = "";
        speakerTag.text = "";
        textbox.SetActive(false);
    }

    public void TurnOffDialogue()
    {
        // Clear the text and turn off the textbox
        box.SetBool("Turn On", false);
        text.text = "";
        speakerTag.text = "";
        isPlayingDialogue = false;

        // Turn Off the speech bubble at the last index
        // Remember that arrays are 0 indexed so the last index is the length minus 1
        dialogue[dialogue.Length - 1].speechBubble.SetActive(false);
        index = 1;
    }

    public void StartDialogue(Dialogue[] dia)
    {
        dialogue = dia;
        textbox.SetActive(true);
        box.SetBool("Turn On", true);
        isPlayingDialogue = true;
        text.text = dialogue[0].words;
        speakerTag.text = dialogue[0].name;

        //Turn on the first speech bubble
        dialogue[0].speechBubble.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isPlayingDialogue)
        {
            if (index < dialogue.Length)
            {
                //Turn off the previous speech bubble and turn on the current one
                dialogue[index - 1].speechBubble.SetActive(false);
                dialogue[index].speechBubble.SetActive(true);
                text.text = dialogue[index].words;
                speakerTag.text = dialogue[index].name;
                
                index++;
            }
        }
    }
}
