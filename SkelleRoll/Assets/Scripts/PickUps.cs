using UnityEngine;
using System.Collections;

public class InvinciblePick : MonoBehaviour {
    //this will instead (like the enum for moving platforms)
    //hold an enum which will determin what type of powerup it is

    // Use this for initialization 
    private SkullpowerUps powerUp;
    private SkullpowerUps powers;
    public GameObject skull;
    

    public int powerType;//this is the powerup type relating to the index in the powerup script
    //*Right now 0 is invincibility*
    //can add more as we go a long
	void Start () {
        //powerUp = GameObject.FindGameObjectWithTag("player").GetComponent<SkullpowerUps>();
       skull = GameObject.FindGameObjectWithTag("player");
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ply)
    {
        if(ply.gameObject.tag=="player")
        {
            switch(powerType)
            {
                //more cases will be added if there are more powerups
                case 0:
                    powers.powerupActive[0] = true;
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
