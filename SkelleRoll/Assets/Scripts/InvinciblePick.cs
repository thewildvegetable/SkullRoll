using UnityEngine;
using System.Collections;

public class InvinciblePick : MonoBehaviour {
    //this will instead (like the enum for moving platforms)
    //hold an enum which will determin what type of powerup it is

    // Use this for initialization 
    private SkullpowerUps powerUp;

    public Light glowInvins;//the glow invinsibility effect

    public int powerType;//this is the powerup type relating to the index in the powerup script
    //*Right now 0 is invincibility*
    //can add more as we go a long
	void Start () {
        powerUp = GameObject.FindGameObjectWithTag("player").GetComponent<SkullpowerUps>();
        glowInvins.enabled = false; 
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

    public void Invinsibility()
    {

    }
}
