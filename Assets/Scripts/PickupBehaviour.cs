using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Inventory inventory;

    private Item currentItem;

    public void DoPickup(Item item) // item is the object we are picking up 
    {
        if (inventory.IsFull())
        {
            Debug.Log("Inventory full, can't pick up : " + item.name);
            return;
        }

        currentItem = item;

        // Play the character animation for picking up
        playerAnimator.SetTrigger("Pickup");
        // Block the player movement
        playerMoveBehaviour.canMove = false;
    }

    public void AddItemToInvetory()
    {
        // Add the object to the player inventory
        inventory.AddItem(currentItem.itemData);
        // Destroy the picked item
        Destroy(currentItem.gameObject);

        currentItem = null;
    }

    public void ReEnablePlayerMovement()
    {
        // Block the player movement
        playerMoveBehaviour.canMove = true;
    }
}
