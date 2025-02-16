using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public Rigidbody2D circle;
    public float movementspeed;
    public float JumpPower;
    private bool isGrounded;
  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        Vector2 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector2.right;
        }
        if (isGrounded && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space)))
        {
            circle.linearVelocity = new Vector2(circle.linearVelocity.x, JumpPower);
        }
        circle.linearVelocity = new Vector2(moveDirection.x * movementspeed, circle.linearVelocity.y); 
    }


        private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
   

}



