using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public bool pickable;
    public int inventoryIndex;
    
    void Update()
    {
        GetComponent<CircleCollider2D>().enabled = pickable;
        GetComponent<Rigidbody2D>().isKinematic = !pickable;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (pickable && other.gameObject.CompareTag("Player"))
        {
            Inventory inventory = other.gameObject.GetComponentInChildren<Inventory>();
            inventory.placeable[inventoryIndex].quantity += 1;
            Destroy(gameObject);
        }
    }
}
