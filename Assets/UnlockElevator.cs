using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockElevator : Interactable
{
    public GameObject elevatorTrigger;
    public Collider2D elevatorUnlockCollider;
    public Item KeyItemToEleavator;

    public override void Interact()
    {
        if (Inventory.instance.Contains(KeyItemToEleavator.name)){
            elevatorTrigger.SetActive(true);
            elevatorUnlockCollider.enabled = false;
        }
    }
}