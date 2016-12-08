using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class FireWallScript : MonoBehaviour {

    public GameObject fireWall;
    public GameObject gameManager;
    public GameObject target;      //target to seek/path follow
    private float distance = float.MaxValue;
    private Vector3 startPos;
    private int listPos = 0;        //position in the handle list
    public bool enabled = true;
    public float timer = 0;


	// Use this for initialization
	void Start () {
        startPos = fireWall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null && enabled)
        {
            //increment timer
            timer += Time.deltaTime;
            Debug.Log(timer);

            //seek path
            fireWall.transform.position = Vector3.Lerp(startPos, target.transform.position, timer);
            /*seekingForce = fireWall.transform.position - target.transform.position;
            distance = seekingForce.magnitude;
            seekingForce = seekingForce.normalized * seekWeight; //1.3f
            steeringForce = seekingForce - fireWall.transform.forward;*/

            //reset if timer >= 1
            if (timer >= 1)
            {
                listPos++;
                target = gameManager.GetComponent<GameManagerScript>().handles[listPos];
                startPos = fireWall.transform.position;
                timer = 0;
                Debug.Log("reset");
            }

            //make fireWall look at target
            fireWall.transform.LookAt(target.transform);

            //move
            //fireWall.transform.position = fireWall.transform.position - steeringForce;

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
