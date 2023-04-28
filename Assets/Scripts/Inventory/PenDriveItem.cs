using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New PenDriveItem Item", menuName = "Inventory/PenDrive")]
public class PenDriveItem : Item
{
    public Image image;

    public override void Use()
    {
        Debug.Log("[PenDriveItem Item Type] " + name);
    }

}
