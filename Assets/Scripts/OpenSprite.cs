using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSprite : Interactable
{
    public GameObject uiInterface;
    
    void Start()
    {
        uiInterface.SetActive(false);
    }

    public override void Interact()
    {
        Debug.Log("Interacting with OpenSprite");
        uiInterface.SetActive(true);  

        PlayerMovement.SetCurrentInteractable(uiInterface);
    }
}
