using UnityEngine;

public class NetCatch : MonoBehaviour
{
    public bool swinging;
    public BeeCount beeCount;

    void OnTriggerStay2D(Collider2D other)
    {
        if (swinging && other.CompareTag("Bee"))
        {
            swinging = false;
            Destroy(other.gameObject);
            beeCount.caughtBeeCount += 1;
        }
    }
}
