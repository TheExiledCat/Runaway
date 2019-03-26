using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask whatisGround; // var that keeps track of what you want to be able to jump off of
    public Transform floorcheck; //hitbox for ground check
    float checkRadi =0.1f; // size of hitbox groundcheck
    float strafeSpeed =25; // left and right speed
    public float walkSpeed =50; //moving speed
    public float jumpHeight = 7; //jump height
    bool isGrounded; // boolean that keeps track if we are touching something qualified as "ground" or not
    float runSpeed;
    float moveInX; // vvv //take in all inputs
    float moveInZ;
    float lookX;
    float lookS = 20;
    float lookY;
    float rotY;

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
       if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight , rb.velocity.z);//jumping
        }

        
         rotY += lookY * lookS * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, -80, 80f);
        //cam.transform.rotation = new Quaternion(-rotY,0 , 0f,cam.transform.rotation.w);
        transform.Rotate(0, lookX*lookS*Time.deltaTime, 0);


    }
    private void FixedUpdate()
    {

        rb.position += moveInX * transform.forward * Time.deltaTime*walkSpeed;
        rb.position += moveInZ * transform.right * Time.deltaTime * strafeSpeed;
        

       // rb.velocity += new Vector3(transform.forward.x *moveInX * strafeSpeed*Time.deltaTime, rb.velocity.y*Time.deltaTime, -moveInZ * walkSpeed*Time.deltaTime);//moving
    }
}
