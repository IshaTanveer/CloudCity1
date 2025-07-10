using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    //parameters for moving
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movingSpeed;
    private Vector2 vector2;
    [SerializeField] InputActionReference inputActionRef;

    //parameters for animations
    private Animator animator;

    void Start()
    {
        inputActionRef.action.Enable();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        vector2 = inputActionRef.action.ReadValue<Vector2>();
        movePlayer(vector2); //with new input system
        setIdleAndWalkAnimation(vector2);

    }

    private void movePlayer(Vector2 vector2)
    {
        rb.linearVelocity = new Vector2(vector2.x * movingSpeed, vector2.y * movingSpeed);
    }
    private void setIdleAndWalkAnimation(Vector2 vector2)
    {
        if (vector2 != Vector2.zero)
        {
            animator.SetFloat("moveX", vector2.x);
            animator.SetFloat("moveY", vector2.y);
        }

        animator.SetBool("isMoving", rb.linearVelocity.magnitude > 0); //walking animation
    }
}
