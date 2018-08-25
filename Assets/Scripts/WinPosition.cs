﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPosition : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !other.transform.parent.GetComponent<Character>().isDead)
        {
            other.transform.parent.GetComponent<Character>().Win();
        }
    }
}
