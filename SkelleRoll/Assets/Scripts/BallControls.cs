using UnityEngine;
using System.Collections;

public class BallControls : MonoBehaviour {

    public float speed;
    public float jumpCooldown;

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

        if(Input.GetKey(KeyCode.Space) && jumpCooldown > 150)
        {
            yspeed = 30;
            jumpCooldown = 0;
        }

        Vector3 force = new Vector3(xspeed, yspeed, zspeed);

        rb.AddForce(force * speed);

        jumpCooldown += 1;
    }
}

