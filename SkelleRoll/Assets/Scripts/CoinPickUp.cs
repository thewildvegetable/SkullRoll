using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

    // Use this for initialization
    //public SkullpowerUps powers;
    private SkullpowerUps powerUp;
    private GameObject skull;
    private int powerType = 1;//this is the double score
    void Start () {
        skull = GameObject.FindGameObjectWithTag("player");
        powerUp = skull.GetComponent<SkullpowerUps>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ply)
    {
        if (ply.gameObject.tag == "player")
        {
            powerUp.IncreaseScore();
            Destroy(this.gameObject);
        }
    }
}
