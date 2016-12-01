using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

    // Use this for initialization
    public SkullpowerUps powers;
    private int powerType = 1;//this is the double score
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ply)
    {
        if (ply.gameObject.tag == "player")
        {
            powers.IncreaseScore();
            Destroy(this.gameObject);
        }
    }
}
