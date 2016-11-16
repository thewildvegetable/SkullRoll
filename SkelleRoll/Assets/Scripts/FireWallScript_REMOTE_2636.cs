using UnityEngine;
using System.Collections;

public class FireWallScript : MonoBehaviour {

    public GameObject fireWall;
    public GameObject gameManager;
    public GameObject target;      //target to seek/path follow
    private float distance = float.MaxValue;
    private Vector3 seekingForce = Vector3.zero;
    private Vector3 steeringForce = Vector3.zero;
    public float seekWeight = 0.8f;
    private int listPos = 0;        //position in the handle list

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            //reset steering force
            steeringForce = Vector3.zero;

            //seek path
            seekingForce = target.transform.position - fireWall.transform.position;
            distance = seekingForce.magnitude;
            seekingForce = seekingForce.normalized * seekWeight; //1.3f
            steeringForce = seekingForce - fireWall.transform.forward;

            //check distance between fireWall and target
            if (distance <= 1)
            {
                listPos++;
                target = gameManager.GetComponent<GameManagerScript>().handles[listPos];
            }

            //make fireWall look at target
            fireWall.transform.LookAt(target.transform);

            //move
            fireWall.transform.position = fireWall.transform.position + steeringForce;

            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + .02f);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("floor"))
        {
            Destroy(col.gameObject);
        }
    }
}
