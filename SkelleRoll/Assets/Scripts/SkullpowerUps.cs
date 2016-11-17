using UnityEngine;
using System.Collections;

public class SkullpowerUps : MonoBehaviour {

    // Use this for initialization
    private float currInvinsTime;//current time invinsible

    private bool[] powerupActive;//a bunch of bools to tell which powerup is active
    public float[] powerupTime;//tells how long the powerup corresponding is active for
    private float[] powerCurrTime;//tells how long the powerup has been active for
    /// <summary>
    /// In array index:
    /// 0 is invinsibility
    /// </summary>

    void Start () {
        powerupActive[0] = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
