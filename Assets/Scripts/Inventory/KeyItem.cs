using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New KeyItem Item", menuName = "Inventory/Key")]
public class KeyItem : Item
{

    public override void Use()
    {
        Debug.Log("[KeyItem Item Type] " + name);
    }

}
