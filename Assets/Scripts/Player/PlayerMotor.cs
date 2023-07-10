using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 3f;
    public float gravity = -9.8f;
    public float jumpHeight = 0.5f;
    public bool sprinting;

    // Start is called before the first frame update

    void Start()
    {
        controller = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -0.5f * gravity);
        }
    }
    
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 6.5f;
        else
            speed = 4f;
    }
}
