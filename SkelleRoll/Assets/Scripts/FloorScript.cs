using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    float time;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        //if time passed a certain point then delete this
        if (time >= 20)
        {
            Destroy(this);
        }
	}
}
