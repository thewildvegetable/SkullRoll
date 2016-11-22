using UnityEngine;
using System.Collections;

public class InvinciblePick : MonoBehaviour {
    //this will instead (like the enum for moving platforms)
    //hold an enum which will determin what type of powerup it is

    // Use this for initialization 
    private SkullpowerUps powerUp;

    private int numPowerUp;//for determining what type of powerup it is
    public int powerType;//this is the powerup type relating to the index in the powerup script
    //*Right now 0 is invincibility*
    //can add more as we go a long
	void Start () {
	
	}

    public int NumPowerUp
    {
        get { return numPowerUp; }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ply)
    {
        if(ply.gameObject.tag=="player")
        {

        }
    }
}
