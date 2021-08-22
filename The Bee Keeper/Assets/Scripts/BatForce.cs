using UnityEngine;

public class BatForce : MonoBehaviour
{
    public bool swinging;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (swinging && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Floor"))
        {
            Destroy(other.gameObject);
        }
    }
}
