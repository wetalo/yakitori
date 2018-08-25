using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform playerCharacter;

    public bool lockXAxis = false;
    public bool lockYAxis = false;

    float previousX = 0f;
    float previousY = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
        float xCoordinate = transform.position.x;
        if (!lockXAxis)
        {
            xCoordinate += (playerCharacter.position.x - previousX);
            previousX = playerCharacter.position.x;
        }

        float yCoordinate = transform.position.y;
        if (!lockYAxis)
        {
            yCoordinate += (playerCharacter.position.y - previousY);
            previousY = playerCharacter.position.y;
        }

        this.transform.position = new Vector3 (xCoordinate, yCoordinate, transform.position.z);
    }

    public void LockOnX()
    {
        previousX = playerCharacter.position.x;
        lockXAxis = true;
    }

    public void LockOnY()
    {
        previousY = playerCharacter.position.y;
        lockYAxis = true;
    }

    public void UnlockOnX()
    {
        lockXAxis = false;
    }

    public void UnlockOnY()
    {
        lockYAxis = false;
    }
}
