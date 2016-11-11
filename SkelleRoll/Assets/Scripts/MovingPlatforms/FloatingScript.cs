using UnityEngine;
using System.Collections;

public class FloatingScript : MonoBehaviour {
    //this is aesthetics for an object to look like it is slowly 
    //floating up and down

    // Use this for initialization
    public float frequ;//the frequency of the object moving up and down
    public float mag;//the magnitude
    private float posY;//the y starting position

    void Start () {
        posY = transform.position.y;//getting the y value
    }
	
	// Update is called once per frame
	void Update () {
        //the object moving up and down around the same initial y location
        float nextY = posY + mag * Mathf.Cos(frequ * Time.time);
        transform.position = new Vector3(transform.position.x, nextY, transform.position.z);
    }
}
