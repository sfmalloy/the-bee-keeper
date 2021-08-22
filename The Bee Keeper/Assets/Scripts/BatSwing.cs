using UnityEngine;

public class BatSwing : MonoBehaviour
{
    Animator animator;
    BatForce batForce;

    void Start()
    {
        animator = GetComponent<Animator>();
        batForce = GetComponentInChildren<BatForce>();
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("SwingAnimation") && Input.GetButtonDown("Swing"))
            animator.SetTrigger("Swing");
    }

    public void OnSwingStart() 
    {
        batForce.swinging = true;
    }

    public void OnSwingStop()
    {
        batForce.swinging = false;
    }
}


