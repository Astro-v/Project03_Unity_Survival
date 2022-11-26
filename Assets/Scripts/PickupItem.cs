using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;

    public PickupBehaviour playerPickupBehaviour;

    [SerializeField]
    private GameObject pickupText;

    [SerializeField]
    private LayerMask layerMask; // Put the layer on item mean we only detect pickable object


    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))// On vérifie si ce que l'on regarde est un item (si il a le tag item)
            {
                // Debug.Log("There is an item if front of us");
                pickupText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        else
        {
            pickupText.SetActive(false);
        }
    }
}
