using UnityEngine;
using System.Collections;

public class FireWallScript : MonoBehaviour {

    public GameObject fireWall;
    private ArrayList handles = new ArrayList();   //all the handles in the scene
    public GameObject target;      //target to seek/path follow
    private float distance = float.MaxValue;
    private Vector3 seekingForce = Vector3.zero;
    private Vector3 steeringForce = Vector3.zero;
    public float seekWeight = 1.3f;

	// Use this for initialization
	void Start () {
        handles = new ArrayList();
        handles.AddRange(GameObject.FindGameObjectsWithTag("frontHandle"));
        handles.AddRange(GameObject.FindGameObjectsWithTag("rearHandle"));
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
                handles = new ArrayList();
                handles.AddRange(GameObject.FindGameObjectsWithTag("frontHandle"));
                handles.AddRange(GameObject.FindGameObjectsWithTag("rearHandle"));
                if (handles.Count > 0)
                {
                    GameObject nextTarget = target;
                    float shortestDist = float.MaxValue;
                    float tempDist = float.MaxValue;
                    foreach (GameObject temp in handles)
                    {
                        //get distance to next handle in the array
                        tempDist = (temp.transform.position - fireWall.transform.position).magnitude;

                        //check if tempDistance is > 1 (ie not the distance to current target) and closest handle
                        if (tempDist > 1 && tempDist < shortestDist)
                        {
                            shortestDist = tempDist;
                            nextTarget = temp;
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
        if (!col.gameObject.CompareTag("floor"))
        {
            Destroy(col.gameObject);
        }
    }
}
