using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class FireWallScript : MonoBehaviour {

    public GameObject gameManager;
    public GameObject target;      //target to seek/path follow
    private float distance = float.MaxValue;
    private Vector3 startPos;
    private int listPos = 0;        //position in the handle list
    public bool enabled = true;
    public float timer = 0;
    public float timeChange = 0.2f;


	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null && enabled)
        {
            //increment timer
            timer += timeChange * Time.deltaTime;

            //seek path
            transform.position = Vector3.Lerp(startPos, target.transform.position, timer);
            /*seekingForce = fireWall.transform.position - target.transform.position;
            distance = seekingForce.magnitude;
            seekingForce = seekingForce.normalized * seekWeight; //1.3f
            steeringForce = seekingForce - fireWall.transform.forward;*/

            //reset if timer >= 1
            if (timer >= 1)
            {
                listPos++;
                target = gameManager.GetComponent<GameManagerScript>().floors[listPos];
                startPos = transform.position;
                timer = 0;
                timeChange = 0.9f;  //speed up firewall after first part
            }

            //make fireWall look at target
            transform.LookAt(target.transform);

            //move
            //fireWall.transform.position = fireWall.transform.position - steeringForce;

            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + .02f);
        }
        else
        {
            if (gameManager.GetComponent<GameManagerScript>().floors[listPos] != null)
            {
                target = gameManager.GetComponent<GameManagerScript>().floors[listPos];
            }
            else
            {
                listPos++;
                target = gameManager.GetComponent<GameManagerScript>().floors[listPos];
            }
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
