using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(Animator))]
public class MainPlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private UnityEngine.Vector2 move;

    [SerializeField]
    private float speed = 5f;

    private Animator animator;

    readonly int ANI_Walk = Animator.StringToHash("Walk"); //HASHED animation


    public float gravity = -9.81f; // Standard Earth gravity
    private float yVelocity; //for gravity


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<UnityEngine.Vector2>(); 

       // Debug.Log($"OnMove {Time.frameCount}"); //debug log to check on frames per move (if character moves lol)

    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 moveDirection = transform.forward * move.y + transform.right * move.x; //change to vector 3 to be able to move forward

        //rotation for character
        if (move.x != 0 || move.y != 0)
        {
            transform.Rotate(0, move.x * 100f * Time.deltaTime, 0);
        }

        //combine delta with already existing movement since vector3 is being used now
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Apply gravity
        if (characterController.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        yVelocity += gravity * Time.deltaTime;

        moveDirection.y = yVelocity;

        //combine delta with already existing movement since vector3 is being used now
        characterController.Move(moveDirection * speed * Time.deltaTime);


        // animation
        if (move.x != 0 || move.y != 0)
        {
            //animator.SetBool("Walk", true)
            animator.SetBool(ANI_Walk, true);
        }
        else
        {
            animator.SetBool(ANI_Walk, false);
        }
    }
}
