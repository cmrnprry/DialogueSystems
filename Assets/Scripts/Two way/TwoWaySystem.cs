using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // NEED TO IMPORT THIS TO USE UNITY UI
using TMPro; //NEED TO IMPORT THIS TO USE TMPRO


public class TwoWaySystem : MonoBehaviour
{
    public GameObject textbox; //Text box that will be the parent
    public TextMeshProUGUI text; //Text Gameobject that  will hold the text
    public TextMeshProUGUI speakerTag; //speaker text Gameobject that  will hold the text

    private Dialogue[] dialogue; //array of dialogue
    private int index = 1; //What line of dialogue we're on
    private bool isPlayingDialogue = false; //check if we should be playing dialogue

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
        text.text = "";
        speakerTag.text = "";
        textbox.SetActive(false);
        isPlayingDialogue = false;
        index = 1;
    }

    public void StartDialogue(Dialogue[] dia)
    {
        dialogue = dia;
        textbox.SetActive(true);
        isPlayingDialogue = true;
        text.text = dialogue[0].words;
        speakerTag.text = dialogue[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isPlayingDialogue)
        {
            if (index < dialogue.Length)
            {
                text.text = dialogue[index].words;
                speakerTag.text = dialogue[index].name;
                index++;
            }
        }
    }
}
