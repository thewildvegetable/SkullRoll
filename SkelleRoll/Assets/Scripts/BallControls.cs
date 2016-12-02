using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;
    private bool canJump = false;
    private float jumpForce = 30;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xspeed = Input.GetAxis("Horizontal");
        float zspeed = Input.GetAxis("Vertical");

        float yspeed = 0f;

        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            yspeed = jumpForce;
            canJump = false;
        }

        Vector3 force = new Vector3(xspeed, yspeed, zspeed);

        rb.AddForce(force * acceleration);
        Vector3 temp = rb.velocity;
        temp = Vector3.ClampMagnitude(temp, maxSpeed);
        rb.velocity = temp;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            canJump = true;
        }
    }
}

