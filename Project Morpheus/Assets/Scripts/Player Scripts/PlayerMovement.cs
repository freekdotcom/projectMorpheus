using UnityEngine;
using System.Collections;

public class PlayerMovement
     : MonoBehaviour {

    private Rigidbody rigidBody;
    private float horizontalMovementSpeed;
    private float verticalMovementSpeed;
    public float jumpHeight;
    private Vector3 movement;
    private float distToGround;

    public int mouseRotationSpeed;
    public float speed;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        movement = new Vector3(horizontalMovementSpeed, verticalMovementSpeed, jumpHeight);
        distToGround = GetComponent<Collider>().bounds.extents.y;

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * mouseRotationSpeed);
    }

    // Update is called once per frame
    void FixedUpdate () {


        //Handles the movement
        horizontalMovementSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        verticalMovementSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalMovementSpeed * -speed, 0, verticalMovementSpeed * -speed));

        //rigidBody.AddRelativeForce(horizontalMovementSpeed * -speed, 0, verticalMovementSpeed * -speed, ForceMode.Impulse);

        Debug.Log(IsGrounded());
        //Handles the jumping
        if(Input.GetKeyDown("space") && IsGrounded())
        {
            Debug.Log("Jump detected");
            rigidBody.AddForce(transform.up * jumpHeight);
        }
	}

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }
}
