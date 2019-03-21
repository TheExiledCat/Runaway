using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask whatisGround; // var that keeps track of what you want to be able to jump off of
    public Transform floorcheck; //hitbox for ground check
    float checkRadi =0.1f; // size of hitbox groundcheck
    float strafeSpeed =50; // left and right speed
    float walkSpeed =100; //moving speed
    float jumpHeight = 7; //jump height
    bool isGrounded; // boolean that keeps track if we are touching something qualified as "ground" or not
    float runSpeed;
    float moveInX; // vvv //take in all inputs
    float moveInZ;
    float lookX;
    float lookS = 20;
    float lookY;

    public Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        lookY = Input.GetAxis("Mouse Y");
        lookX = Input.GetAxis("Mouse X"); //set vars equal to our input
        isGrounded = Physics.CheckSphere(floorcheck.position, checkRadi,whatisGround); // check for collision at hitbox position
        moveInZ = Input.GetAxis("Horizontal");
        moveInX = Input.GetAxis("Vertical");//set vars equal to input from mouse
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);//jumping
        }
        


    
   
    }
    private void FixedUpdate()
    {

        
          
         rb.velocity += new Vector3(moveInX * strafeSpeed, rb.velocity.y, -moveInZ * walkSpeed);//moving
    }
}
