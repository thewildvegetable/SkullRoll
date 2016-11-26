using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SkullpowerUps : MonoBehaviour
{

	// Use this for initialization

    private float currInvinsTime;//current time invinsible

    public Light glowInvins;//the glow invinsibility effect
    public List<bool> powerupActive;//a bunch of bools to tell which powerup is active
    public List<float> powerupTime;//tells how long the powerup corresponding is active for
                                   // private float[] powerCurrTime;

    private bool canBeHit;//tells if user can take damage in this state
    private List<float> powerCurrTime = new List<float>();//tells how long the powerup has been active for
                                      /// <summary>
                                      /// In array index:
                                      /// 0 is invinsibility
                                      /// </summary>
    void Start () {
        powerupActive[0] = false;
        glowInvins.enabled = false;
        canBeHit = true;//the user can take damage
        powerCurrTime.Add(0);
    }


	// Update is called once per frame
	void Update () {
        //this can be replaced by a for loop in the future.
        if(powerupActive[0]==true)
        {
            if(powerCurrTime[0] < powerupTime[0])
            {
                Invinsible();
                powerCurrTime[0]++;
            }
            else if(powerCurrTime[0] >= powerupTime[0])
            {
                powerCurrTime[0] = 0;
                powerupActive[0] = false;
                glowInvins.enabled = false;
            }
        }
	
	}

    private void Invinsible()
    {
        canBeHit = false;
        glowInvins.enabled = true;
    }
}
