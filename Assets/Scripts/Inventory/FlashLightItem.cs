using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New FlashLight Item", menuName = "Inventory/FlashLight")]
public class FlashLightItem : Item
{

    public override void PickUp()
    {
        base.PickUp();

        string[] sentences = new string[3];
        sentences[0] = "YOU TURNED ON THE FLASHLIGHT!";
        sentences[1] = "YOU CAN TURN IT OFF BY PRESSING F.";
        sentences[2] = "YOU CAN ALSO TURN IT ON BY PRESSING F.";

        string name = "DAVI REIS";

        GameObject dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
        if (dialogueBox != null)
        {
            Debug.Log("DialogueBox found!");
            dialogueBox.GetComponent<DialogueScript>().SetNewDialogue(sentences, name);
        }
        else
        {
            Debug.Log("DialogueBox not found!");
        }

    }

    public override void Use()
    {
        PlayerMovement.instance.SwitchFlashlight();    
    }

}
