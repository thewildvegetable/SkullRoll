using UnityEngine;
using System.Collections;

public class CameraBallScript : MonoBehaviour {

    // Use this for initialization
    public GameObject skull;
    private Vector3 pos;
	void Start () {
        pos = this.transform.position - skull.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (skull != null)
        {
            this.transform.position = skull.transform.position + pos;
        }
	}
}
