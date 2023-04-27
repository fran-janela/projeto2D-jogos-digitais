using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static GameObject currentInteractable;

    public GameObject interactIcon;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Animator bodyAnimator;


    public Collider2D interactCollider;

    public GameObject flashlight;
    private static bool flashlight_on = false;

    private Vector2 movement;

    public static void SetCurrentInteractable(GameObject interactable)
    {
        currentInteractable = interactable;
    }

    void Awake()
    {
        interactIcon.SetActive(false);
        flashlight.SetActive(flashlight_on);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchFlashlight();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentInteractable != null)
        {
            currentInteractable.SetActive(false);
            UnfreezePlayer();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        bodyAnimator.SetFloat("Horizontal", movement.x);
        bodyAnimator.SetFloat("Vertical", movement.y);
        bodyAnimator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0)
        {
            interactCollider.offset = new Vector2(movement.x, -0.5f);
            flashlight.transform.rotation = Quaternion.Euler(0, 0, 180 + (movement.x*90));
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", 0);

            bodyAnimator.SetFloat("LastHorizontal", movement.x);
            bodyAnimator.SetFloat("LastVertical", 0);
        }
        else if (movement.y != 0)
        {
            flashlight.transform.rotation = Quaternion.Euler(0, 0, 90 - (movement.y*90));
            interactCollider.offset = new Vector2(0, movement.y - 0.5f);
            animator.SetFloat("LastHorizontal", 0);
            animator.SetFloat("LastVertical", movement.y);

            bodyAnimator.SetFloat("LastHorizontal", 0);
            bodyAnimator.SetFloat("LastVertical", movement.y);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void OpenInteractIcon()
    {
        interactIcon.SetActive(true);
    }

    public void CloseInteractIcon()
    {
        interactIcon.SetActive(false);
    }

    public void FreezePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public static void UnfreezePlayer()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void CheckInteraction()
    {
        Vector2 direction = new Vector2(animator.GetFloat("LastHorizontal"), animator.GetFloat("LastVertical"));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, LayerMask.GetMask("Trigger Raycast"));
        if (hit)
        {
            Debug.Log("Interacting with " + hit.collider.name);
            if (hit.transform.GetComponent<Interactable>())
            {
                hit.collider.GetComponent<Interactable>().Interact();
                FreezePlayer();
            }
        }
    }

    public void SwitchFlashlight()
    {
        flashlight.SetActive(!flashlight_on);
        flashlight_on = !flashlight_on;
    }
}
