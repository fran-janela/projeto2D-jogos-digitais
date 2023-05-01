using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerDisplay : MonoBehaviour
{

    public PushButtonLocker[] pushButtonLockers;

    public string[] correctCode;

    public Button tryButton;

    public Image lockerDoor;

    public GameObject lockerInterface;


    void Start()
    {
        // subscribe to event OnButtonPressed
        PushButtonLocker.OnButtonPressed += CheckCode;

        tryButton.onClick.AddListener(TryCode);
    }

    private void CheckCode(string character)
    {
        // check if all 4 characters are set
        if (pushButtonLockers[0].GetCurrentCharacter() != "" && pushButtonLockers[1].GetCurrentCharacter() != "" && pushButtonLockers[2].GetCurrentCharacter() != "" && pushButtonLockers[3].GetCurrentCharacter() != "")
        {
            // check if all 4 characters are correct
            if (pushButtonLockers[0].GetCurrentCharacter() == correctCode[0] && pushButtonLockers[1].GetCurrentCharacter() == correctCode[1] && pushButtonLockers[2].GetCurrentCharacter() == correctCode[2] && pushButtonLockers[3].GetCurrentCharacter() == correctCode[3])
            {
                lockerDoor.enabled = false;
                lockerInterface.SetActive(false);
            }
        }
    }

    private void TryCode()
    {


        if (pushButtonLockers[0].GetCurrentCharacter() != "" && pushButtonLockers[1].GetCurrentCharacter() != "" && pushButtonLockers[2].GetCurrentCharacter() != "" && pushButtonLockers[3].GetCurrentCharacter() != "")
        {
            if (pushButtonLockers[0].GetCurrentCharacter() == correctCode[0] && pushButtonLockers[1].GetCurrentCharacter() == correctCode[1] && pushButtonLockers[2].GetCurrentCharacter() == correctCode[2] && pushButtonLockers[3].GetCurrentCharacter() == correctCode[3])
            {
                lockerDoor.enabled = false;
                lockerInterface.SetActive(false);

                Debug.Log("Correct code");
            }
            else
            {
                Debug.Log("Wrong code");
            }
        }
    }

    private void OnDestroy()
    {
        PushButtonLocker.OnButtonPressed -= CheckCode;
    }
}
