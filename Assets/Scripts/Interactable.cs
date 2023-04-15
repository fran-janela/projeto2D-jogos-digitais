using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public abstract class Interactable : MonoBehaviour
{
    public void Reset()
    {
        GetComponent<PolygonCollider2D>().isTrigger = true;
    }


    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().OpenInteractIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().CloseInteractIcon();
        }
    }
}
