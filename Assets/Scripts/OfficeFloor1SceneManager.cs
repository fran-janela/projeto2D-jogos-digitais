using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeFloor1SceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBody;
    public GameObject playerFeet;
    public GameObject camera;

    public GameObject MaintenenceDoorOpen, MaintenenceDoorClosed;
    public Collider2D DoorTrigger;
    public Animator changePlayerRoomAnim;
    private Vector2 warpPosition;
    private Vector2 cameraMinPos;
    private Vector2 cameraMaxPos;
    private bool changeRoomActive = false;
    private bool FadeIn = false;
    private bool FadeOut = false;
    public GameObject ElevatorTrigger;

    public void Start(){
        if (Inventory.instance.Contains("Elevator Key")){
            ElevatorTrigger.SetActive(true);
        } else {
            ElevatorTrigger.SetActive(false);
        }
    }

    public void Update(){
        if (changeRoomActive) {
            if(FadeIn){
                playerFeet.GetComponent<AudioSource>().Stop();
                player.GetComponent<Animator>().SetFloat("Speed", 0f);
                playerBody.GetComponent<Animator>().SetFloat("Speed", 0f);
                changePlayerRoomAnim.Play("FadeIn");
                FadeIn = false;
                FadeOut = true;
            }
            else if(!changePlayerRoomAnim.GetCurrentAnimatorStateInfo(0).IsName("FadeIn") && FadeOut){
                player.GetComponent<Rigidbody2D>().position = warpPosition;
                camera.GetComponent<cameraScript>().maxPosition = cameraMaxPos;
                camera.GetComponent<cameraScript>().minPosition = cameraMinPos;
                changePlayerRoomAnim.Play("FadeOut");
                FadeOut = false;
            }
            else if(!changePlayerRoomAnim.GetCurrentAnimatorStateInfo(0).IsName("FadeOut") && !FadeOut && !FadeIn){
                player.GetComponent<PlayerMovement>().enabled = true;
                changeRoomActive = false;
            }
        }
    }

    public void changeRoom(Vector2 DesireWarpPosition, Vector2 CameraMinPos, Vector2 CameraMaxPos){
        warpPosition = DesireWarpPosition;
        cameraMinPos = CameraMinPos;
        cameraMaxPos = CameraMaxPos;
        changeRoomActive = true;
        FadeIn = true;
    }

    public void KeypadCorrectSequence(string door){
        if (door == "Maintenence"){
            MaintenenceDoorClosed.SetActive(false);
            DoorTrigger.enabled = false;
            MaintenenceDoorOpen.SetActive(true);
        }
    }

}
