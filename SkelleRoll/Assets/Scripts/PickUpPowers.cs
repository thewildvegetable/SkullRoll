using UnityEngine;
using System.Collections;

public class PickUpPowers : MonoBehaviour {

    //this will instead (like the enum for moving platforms)
    //hold an enum which will determin what type of powerup it is

    // Use this for initialization 
    private SkullpowerUps powerUp;
    private SkullpowerUps powers;
    private GameObject skull;


    public int powerType;//this is the powerup type relating to the index in the powerup script
                         //*Right now 0 is invincibility*
                         //can add more as we go a long
    void Start()
    {
        //powerUp = GameObject.FindGameObjectWithTag("player").GetComponent<SkullpowerUps>();
        skull = GameObject.FindGameObjectWithTag("player");
        powerUp = skull.GetComponent<SkullpowerUps>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider ply)
    {
        if (ply.gameObject.tag == "player")
        {
           powers.powerupActive[powerType] = true;
                Destroy(this.gameObject);

            
        }
    }
}
