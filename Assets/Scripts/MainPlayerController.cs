using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(Animator))]
public class MainPlayerController : MonoBehaviour
{
    
    private CharacterController characterController;

    private UnityEngine.Vector2 move;

    [SerializeField]
    private float speed = 5f; //speed

    [SerializeField]
    private float rotationSpeed = 100f; //rotation speed

    private Animator animator;

    //animation var for walking
    readonly int ANI_Walk = Animator.StringToHash("Walk");

    //gravity var s 
    public float gravity = -9.81f;
    private float yVelocity;

    void Start()
    {
        //initialize animator and component 
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    //move function
    private void OnMove(InputValue value)
    {
        move = value.Get<UnityEngine.Vector2>();
    }

    void Update()
    {
        // forward/back movement
        UnityEngine.Vector3 moveDirection = transform.forward * move.y;

        // rotation
        if (Mathf.Abs(move.x) > 0.01f)
        {
            transform.Rotate(
                0,
                move.x * rotationSpeed * Time.deltaTime,
                0
            );
        }

        // gravity so mouse doesnt float lol
        if (characterController.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        yVelocity += gravity * Time.deltaTime;

        moveDirection.y = yVelocity;

        // single movement call
        characterController.Move(
            moveDirection * speed * Time.deltaTime
        );

        // walking animation
        bool isMoving =
        Mathf.Abs(move.x) > 0.01f || Mathf.Abs(move.y) > 0.01f;

        animator.SetBool(ANI_Walk, isMoving);
    }
}