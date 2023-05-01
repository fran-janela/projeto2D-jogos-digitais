using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeFloor2SceneManager : MonoBehaviour
{
    public GameObject TriggerLockerOpened12, TriggerLockerKeyPad12;
    void Start()
    {
        
    }

    public void KeypadCorrectSequence(string door){
        if (door == "Locker12"){
            TriggerLockerOpened12.SetActive(true);
            TriggerLockerKeyPad12.SetActive(false);
        }
    }
}
