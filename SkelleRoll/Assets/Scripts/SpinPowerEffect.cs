using UnityEngine;
using System.Collections;

public class SpinPowerEffect : MonoBehaviour {

    // Use this for initialization
    public int spinRate;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(this.transform.up, spinRate);
	}
}
