using UnityEngine;
using System.Collections;

public class AirCurrent : MonoBehaviour {

    public GameObject player;
    public float launchUpForce;
    //public float reduceDraft;
   // public float airResistance;
    // Use this for initialization
    bool leavingZone;//tells if user is leaving the trigger zone
    //public float dragDecrease;
   // public float dragIncrease;
    public bool isTilted;//tells if the vent is on a slant;

    public ParticleSystem particles;
	void Start () {
        //leavingZone=true;
        particles.Pause();//do not want to particles to show at the beginning
    }
	
	// Update is called once per frame
	void Update () {
        /*
	if(leavingZone==true)
        {
            if (player.GetComponent<Rigidbody>().drag > 0)
            {
               player.GetComponent<Rigidbody>().drag -= dragDecrease;
               if(player.GetComponent<Rigidbody>().drag< 0)
               {
                    player.GetComponent<Rigidbody>().drag = 0;
               }
            }

        }
        

    else if(leavingZone==false)
        {
            if(player.GetComponent<Rigidbody>().drag < airResistance)
            {
               player.GetComponent<Rigidbody>().drag += dragIncrease;
            }
        }

    */

    }


    void OnTriggerStay(Collider coll)
    {
        if(coll.tag=="player")
        {
                float dist = coll.transform.position.y - transform.parent.transform.position.y;
                leavingZone = false;
                //particles.Play();
                // float dist = Vector3.Distance(coll.transform.position, this.transform.parent.transform.position);
                if (dist == 0)
                {
                    dist = 0.05f;//as long as not 0, it good
                }
                else
                {
                    // player.GetComponent<Rigidbody>().velocity.Normalize();
                    //player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, launchUpForce / (dist * reduceDraft), 0f));

                    if (isTilted == false)//if vent is on a slant, launchforce is based on dist
                        player.GetComponent<Rigidbody>().AddForce(transform.up * (launchUpForce / (dist)));

                    else if (isTilted == true)
                        player.GetComponent<Rigidbody>().AddForce(transform.up * (launchUpForce));

                }
            }
        
    }



    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "player")
        {
   
               leavingZone = true;
        }

    }
}
