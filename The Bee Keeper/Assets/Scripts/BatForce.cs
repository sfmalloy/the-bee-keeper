using UnityEngine;

public class BatForce : MonoBehaviour
{
    public bool swinging;

    void OnTriggerStay2D(Collider2D other)
    {
        if (swinging)
        {
            DestroyAndDrop(other.gameObject, other.gameObject.GetComponents<DropItem>());
            swinging = false;
        }
    }

    void DestroyAndDrop(GameObject other, params DropItem[] dropItems)
    {
        foreach (DropItem dropItem in dropItems)
        {
            int numToDrop = Random.Range(dropItem.minDrop, dropItem.maxDrop + 1);
            for (int i = 0; i < numToDrop; ++i)
            {
                Vector3 posOffset = new Vector3(Random.Range(-1.0f, 2.0f), 0);
                Instantiate(dropItem.itemToDrop, other.transform.position + posOffset, Quaternion.identity);
            }
        }
        Destroy(other);
    }
}
