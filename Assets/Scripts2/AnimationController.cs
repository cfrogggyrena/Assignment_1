using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //T-bag your enemies hehehehe
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
            animator.SetTrigger("Tbag");

        //punch your enemies, option 1
        if (Keyboard.current.kKey.wasPressedThisFrame)
            animator.SetTrigger("Punch");

        //punch your enemies, option 1
        if (Keyboard.current.lKey.wasPressedThisFrame)
            animator.SetTrigger("Kick");

    }
}
