using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorScript : MonoBehaviour {

    public List<GameObject> spawners = new List<GameObject>();
    public GameObject skull;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //if time passed a certain point then delete this
        if (skull.transform.position.z >= this.transform.position.z + 30)
        {
            Destroy(this);
        }
	}
}
