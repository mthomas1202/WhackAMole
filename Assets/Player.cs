using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward,out hit) || Input.GetKeyDown("space"))
        {
            if (hit.transform.GetComponent<Mole>() != null)
            {
                Mole mole = hit.transform.GetComponent<Mole>();
                mole.OnHit();

                score++;
            }
        }
	}
}
