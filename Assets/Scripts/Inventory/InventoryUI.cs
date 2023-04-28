using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Toggling inventory");
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            if (inventoryUI.activeSelf)
                inventoryUI.LeanScale(Vector3.one, 0.25f).setEaseInOutExpo();
            else
                inventoryUI.LeanScale(Vector3.zero, 0.25f).setEaseInOutExpo();
        }        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                Debug.Log("Adding item to slot " + i);
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                Debug.Log("Clearing slot " + i);
                slots[i].ClearSlot();
            }
        }

    }
}
