using UnityEngine;

public class BatSwing : MonoBehaviour, Useable
{
    Animator animator;
    BatForce batForce;

    void Start()
    {
        animator = GetComponent<Animator>();
        batForce = GetComponentInChildren<BatForce>();
    }

    public void OnSwingStart() 
    {
        batForce.swinging = true;
    }

    public void OnSwingStop()
    {
        batForce.swinging = false;
    }

    public void Use()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("SwingAnimation"))
            animator.SetTrigger("Swing");
    }
}
