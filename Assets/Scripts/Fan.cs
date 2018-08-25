using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fan : MonoBehaviour {

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public float power;
    public bool isOn = false;

    public Direction fanDirection;

    public GameObject fan;
    public GameObject blades;

    public float baseForce;

    private ParticleSystem ps;
    public GameObject particleEmitter;
    public bool moduleEnabled;

    public float bladeSpinSpeed = 20f;

    [Header("Power variables")]
    public int powerCost = 2;
   // public PowerManager manager;

    [Header("Keyboard input")]
    public string keyboardKey;
    public Text character;



    // Use this for initialization
    void Start () {
        ps = particleEmitter.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(keyboardKey))
        {
            //manager.UsePower(powerCost);
        }
        
        if (Input.GetKey(keyboardKey)) //&& manager.canUsePower
        {
            isOn = true;
            moduleEnabled = true;

            Vector3 rotationAxis = Vector3.zero;
            switch (fanDirection)
            {
                case Direction.Up:
                    rotationAxis = Vector3.up;
                    break;
                case Direction.Down:
                    rotationAxis = Vector3.down;
                    break;
                case Direction.Left:
                    rotationAxis = Vector3.left;
                    break;
                case Direction.Right:
                    rotationAxis = Vector3.right;
                    break;
            }

            blades.transform.RotateAround(blades.transform.position, rotationAxis, -bladeSpinSpeed * Time.deltaTime);
        }
        else
        {
            isOn = false;
            moduleEnabled = false;
        }
    

        

        var emission = ps.emission;
        emission.enabled = moduleEnabled;
    }

    public void Push(Character player) {
        float force = baseForce + power * 1 / (Vector3.Distance(fan.transform.position, player.gameObject.transform.position));
        player.Push(force, fanDirection);
        
    }

    public void ChangeLetter(string letter)
    {
        keyboardKey = letter;
        character.text = letter.ToUpper();
    }

}
