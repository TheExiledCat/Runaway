using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask whatisGround;
    public Transform floorcheck;
    float checkRadi =0.1f;
    float strafeSpeed =50;
    float walkSpeed =100;
    float jumpHeight = 7;
    bool isGrounded;
    float runSpeed;
    float moveInX;
    float moveInZ;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(floorcheck.position, checkRadi,whatisGround);
        moveInZ = Input.GetAxis("Horizontal");
        moveInX = Input.GetAxis("Vertical");
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
        rb.velocity = new Vector3(moveInX * strafeSpeed, rb.velocity.y, -moveInZ * walkSpeed);
    }
}
