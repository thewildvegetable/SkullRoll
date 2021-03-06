﻿using UnityEngine;
using System.Collections;

public class CameraBallFall: MonoBehaviour
{

    // Use this for initialization
    public GameObject skull;
    private Vector3 pos;
    public GameLoop gl;
    void Start()
    {
        pos = this.transform.position - skull.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (skull != null || gl.gameOver != true)
        {
            // Debug.Log(skull.transform.localPosition.y);
            if (skull.transform.position.y > -40)
            {
                this.transform.position = skull.transform.position + pos;
            }
        }
        else if(gl.gameOver == true)
        {
            this.transform.LookAt(skull.transform.position);
        }
        
    }
}
