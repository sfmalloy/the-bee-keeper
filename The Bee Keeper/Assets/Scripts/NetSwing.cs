using UnityEngine;

public class NetSwing : MonoBehaviour, Useable
{
    Animator animator;
    NetCatch netCatch;

    void Start()
    {
        animator = GetComponent<Animator>();
        netCatch = GetComponentInChildren<NetCatch>();
    }

    public void OnSwingStart() 
    {
        netCatch.swinging = true;
    }

    public void OnSwingStop()
    {
        netCatch.swinging = false;
    }

    public void Use()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("SwingAnimation"))
            animator.SetTrigger("Swing");
    }
}
