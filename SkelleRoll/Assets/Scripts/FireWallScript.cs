using UnityEngine;
using System.Collections;

public class FireWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    //make a global variable of target. in update take target's velocity and apply it to this's position
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + .02f);
	}

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Floor"))
        {
            Destroy(col.gameObject);
        }
    }
}
