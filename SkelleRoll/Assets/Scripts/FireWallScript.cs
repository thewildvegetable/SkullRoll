using UnityEngine;
using System.Collections;

public class FireWallScript : MonoBehaviour {

    public GameObject fireWall;
    private GameObject[] handles;   //all the handles in the scene
    public GameObject target;      //target to seek/path follow
    private float distance = float.MaxValue;
    private Vector3 seekingForce = Vector3.zero;
    private Vector3 steeringForce = Vector3.zero;
    private float seekWeight = 1.3f;

	// Use this for initialization
	void Start () {
        handles = GameObject.FindGameObjectsWithTag("Handle");
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
                //find all handles, find the closest handle that isnt this one
                handles = GameObject.FindGameObjectsWithTag("Handle");
                if (handles.Length > 0)
                {
                    GameObject nextTarget = target;
                    float shortestDist = float.MaxValue;
                    float tempDist = float.MaxValue;
                    for (int i = 0; i < handles.Length; i++)
                    {
                        //get distance to next handle in the array
                        tempDist = (handles[i].transform.position - fireWall.transform.position).magnitude;

                        //check if tempDistance is > 1 (ie not the distance to current target) and closest handle
                        if (tempDist > 1 && tempDist < shortestDist)
                        {
                            shortestDist = tempDist;
                            nextTarget = handles[i];
                        }
                    }
                    target = nextTarget;
                }
                else
                {
                    target = null;
                }
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
        if (!col.gameObject.CompareTag("Floor"))
        {
            Destroy(col.gameObject);
        }
    }
}
