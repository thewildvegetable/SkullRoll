using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    public float speed;
    private bool canJump = true;

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
            yspeed = 30;
        }

        Vector3 force = new Vector3(xspeed, yspeed, zspeed);

        rb.AddForce(force * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            canJump = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            canJump = false;
        }
    }
}

