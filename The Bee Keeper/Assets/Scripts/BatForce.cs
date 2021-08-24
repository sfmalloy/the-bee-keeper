using UnityEngine;

public class BatForce : MonoBehaviour
{
    public bool swinging;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (swinging)
        {
            Destroy(other.gameObject);
        }
    }
}
