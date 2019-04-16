using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FPMovement : MonoBehaviour
{
    public float speed = 12.0f;
    float gravity = -9.8f;

    private float verticalVelocity;
    private float jumpForce = 15.0f;
    private float gravityJump = 14.0f;

    private CharacterController characterControl;
   
    // Start is called before the first frame update
    void Start()
    {
        // Access character controller component on same object this file is attatched on
        characterControl = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "Player")
        {
            movePlayer("Vertical", "Horizontal");
        }
       else if (this.gameObject.tag == "Player2")
        {
            movePlayer("Vertical2", "Horizontal2");
        }
        

    }

    public void movePlayer(string vertAxis, string horzAxis)
    {
        float moveForwardAndBack = Input.GetAxis(vertAxis) * speed; // forward and backward movements is Z axis
        float moveSideToSide = Input.GetAxis(horzAxis) * speed; // Moving side to side is X axis

        // For moving the character controller
        Vector3 characterMovement = new Vector3(moveSideToSide, 0, moveForwardAndBack);
        characterMovement = Vector3.ClampMagnitude(characterMovement, speed); // Diagonal speed is fixed

        characterMovement.y = gravity;
        characterMovement *= Time.deltaTime; //frame independent movement
        characterMovement = transform.TransformDirection(characterMovement); // Convert local to global coordinates

        characterControl.Move(characterMovement);


       /* if (characterControl.isGrounded)
        {
            verticalVelocity = -gravityJump * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravityJump * Time.deltaTime;
        }
        Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);
        characterControl.Move(jumpVector * Time.deltaTime);*/

    }
    
}




