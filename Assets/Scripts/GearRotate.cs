using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotate : MonoBehaviour {

    enum Direction
    {
        clockwise,
        counterClockwise
    }
    [SerializeField]
    Direction direction;
    public float speed;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 axis = Vector3.forward;
        if (direction == Direction.counterClockwise)
        {
            axis = Vector3.back;
        }
        transform.RotateAround(transform.position, axis, speed * Time.deltaTime);
    }
}
