using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanHitZone : MonoBehaviour {

    Fan parentFan;

	// Use this for initialization
	void Start () {
        parentFan = transform.parent.GetComponent<Fan>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && parentFan.isOn)
        {
            parentFan.Push(other.gameObject.transform.parent.GetComponent<Character>());
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && parentFan.isOn)
        {
            parentFan.Push(other.gameObject.GetComponent<Character>());
        }
    }
    */

}
