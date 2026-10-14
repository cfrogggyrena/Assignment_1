using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(Animator))]
public class MainPlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private Vector2 move;

    [SerializeField]
    private float speed = 5f;

    private Animator animator;

    readonly int ANI_Walk = Animator.StringToHash("Walk"); //HASHED animation 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();

       // Debug.Log($"OnMove {Time.frameCount}"); //debug log to check on frames per move (if character moves lol)

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log($"Update {Time.frameCount}"); //debug log to check on frames per update

        //Vector2 deltaMove = move * Time.deltaTime; //to move the same as original input, up and down

        Vector3 moveDirection = transform.forward * move.y + transform.right * move.x; //change to vector 3 to be able to move forward

        //combine delta with already existing movement since vector3 is being used now
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // animation
        if (moveDirection.magnitude > 0.0f)
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
