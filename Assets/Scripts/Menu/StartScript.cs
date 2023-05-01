using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Button startButton;
    private GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        string[] sentences = new string[3];
        sentences[0] = "Olá, eu sou o Pablo, o gerente da fábrica de reatores nucleares.";
        sentences[1] = "Estamos com um problema no reator e precisamos de sua ajuda para resolver.";
        sentences[2] = "Você pode nos ajudar?";

        string name = "PABLO";

        dialogueBox = GameObject.FindGameObjectWithTag("MessageBox");
        if (dialogueBox != null)
        {
            Debug.Log("MessageBox found!");
            dialogueBox.GetComponent<MessagesScript>().SetNewDialogue(sentences, name);
        }
        else
        {
            Debug.Log("MessageBox not found!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
