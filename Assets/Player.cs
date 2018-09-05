﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Hammer hammer;
    public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.GetComponent<Mole>() != null)
                {
                    Mole mole = hit.transform.GetComponent<Mole>();
                    if (mole.isVisible)
                    {
                        mole.OnHit();
                        Vector3 hitVector = new Vector3(mole.transform.position.x -1f,
                                            mole.transform.position.y,
                                            mole.transform.position.z );
                        hammer.Hit(hitVector);
                        score++;
                    }
                }
            }
        }
	}

    void Hit()
    {   
        score++;
    }

}
