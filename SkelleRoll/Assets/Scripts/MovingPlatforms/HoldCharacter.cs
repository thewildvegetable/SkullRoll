using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="player")
        {
            coll.transform.parent = this.transform.parent.transform;
        }
    }


    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "player")
        {
            coll.transform.parent = null;
        }
    }
}
