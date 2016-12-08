using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorScript : MonoBehaviour {

    public List<GameObject> spawners = new List<GameObject>();
    public GameObject firewall;
    private int timer = 0;

	// Use this for initialization
	void Start () {
        firewall = GameObject.FindGameObjectWithTag("Fire");
	}
	
	// Update is called once per frame
	void Update () {
        timer++;

        //if time passed a certain point then delete this
        if (firewall.transform.position.z >= this.transform.position.z + 5)
        {
            Destroy(this.gameObject);
        }
	}
}
