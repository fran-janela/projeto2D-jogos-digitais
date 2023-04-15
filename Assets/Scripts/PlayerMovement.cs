using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject interactIcon;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Animator bodyAnimator;

    private Vector2 movement;

    void Start()
    {
        interactIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
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
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", 0);

            bodyAnimator.SetFloat("LastHorizontal", movement.x);
            bodyAnimator.SetFloat("LastVertical", 0);
        }
        else if (movement.y != 0)
        {
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

    private void CheckInteraction()
    {
        Vector2 direction = new Vector2(animator.GetFloat("LastHorizontal"), animator.GetFloat("LastVertical"));
        Debug.DrawRay(transform.position, direction * 0.5f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, LayerMask.GetMask("Trigger Raycast"));
        if (hit)
        {
            Debug.Log("Interacting with " + hit.collider.name);
            if (hit.transform.GetComponent<Interactable>())
            {
                hit.collider.GetComponent<Interactable>().Interact();
            }
        }
    }
}
