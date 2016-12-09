using UnityEngine;
using System.Collections;

public class RotatingEnemyScript : MonoBehaviour
{

    public int spinSpeedx;
    public int spinSpeedy;
    public int spinSpeedz;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotating on X
        transform.Rotate(Vector3.right * spinSpeedx);

        //Rotating on Y
        transform.Rotate(Vector3.up * spinSpeedy);

        //Rotating on Z
        transform.Rotate(Vector3.forward * spinSpeedz);
    }

    
}