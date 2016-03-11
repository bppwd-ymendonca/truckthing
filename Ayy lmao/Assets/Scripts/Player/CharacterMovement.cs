using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class CharacterMovement : MonoBehaviour {

    CharacterController cc;
    public float speed = 3.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool grounded = false;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called forever
	void FixedUpdate() {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;


        if (cc.isGrounded)
        {

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = cc.velocity.y;
        }
        //apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //Move the controller
        CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = (flags = CollisionFlags.CollidedBelow) != 0; 
    }
}
