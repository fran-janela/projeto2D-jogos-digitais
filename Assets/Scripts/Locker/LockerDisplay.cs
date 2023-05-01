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

    public AudioSource acceptSound;
    public AudioSource denySound;

    public GameObject sceneManager;




    void Start()
    {
        tryButton.onClick.AddListener(CheckCode);
    }

    private void CheckCode()
    {
        // check if all 4 characters are set
        if (pushButtonLockers[0].GetCurrentCharacter() != "" && pushButtonLockers[1].GetCurrentCharacter() != "" && pushButtonLockers[2].GetCurrentCharacter() != "" && pushButtonLockers[3].GetCurrentCharacter() != "")
        {
            // check if all 4 characters are correct
            if (pushButtonLockers[0].GetCurrentCharacter() == correctCode[0] && pushButtonLockers[1].GetCurrentCharacter() == correctCode[1] && pushButtonLockers[2].GetCurrentCharacter() == correctCode[2] && pushButtonLockers[3].GetCurrentCharacter() == correctCode[3])
            {
                lockerDoor.enabled = false;
                acceptSound.Play();
                lockerInterface.SetActive(false);
                PlayerMovement.SetCurrentInteractable(null);
                PlayerMovement.UnfreezePlayer();
                if(transform.parent.tag == "LockBagStorage"){
                    sceneManager.GetComponent<OfficeFloor1SceneManager>().LockCorrectSequence("StorageBag");
                }

            } else {
                Debug.Log("Wrong code");
                denySound.Play();
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

}
