using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayTrigger : MonoBehaviour
{
    public TwoWaySystem system;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            //If you ru into the NPC, Start the dislogue!
            //This takes in the dialogue that is locted on th eNPC
            system.StartDialogue(collision.GetComponent<TwoWayText>().dialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            //Turns off the dialogue
            system.TurnOffDialogue();
        }
    }
}
