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

    // Update is called once per frame
    void FixedUpdate () {

        mouseRotation();

        //Handles the movement of the player
        horizontalMovementSpeed = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        verticalMovementSpeed = -Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalMovementSpeed * -speed, 0, verticalMovementSpeed * -speed));

        //Handles the jumping
        if(Input.GetKeyDown("space") && IsGrounded())
        {
            Debug.Log("Jump detected");
            rigidBody.AddForce(transform.up * jumpHeight);
        }
	}

    //Method that checks if the player is grounded so it can't double jump.
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

    void mouseRotation()
    {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, mouseRotationSpeed * Time.deltaTime);
        }
    }
}
