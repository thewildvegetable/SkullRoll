using UnityEngine;
using System.Collections;

public class AirVent : MonoBehaviour {

    public GameObject player;

    void OnCollisionEnter(Collision col)
    {
        print(col);
        if (col.collider.gameObject.tag == "player")
        {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 300f, 0f));
        }
    }
}
