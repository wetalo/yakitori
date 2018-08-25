using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {

    public int maxPowerAmount;
    public int currentPowerAmount;
    public bool canUsePower = true;

    [SerializeField]
    float blowoutTime;
    float blowoutTimePassed = 0f;

	// Use this for initialization
	void Start () {
        ResetPower();

    }
	
	// Update is called once per frame
	void Update () {
        BlowOut();

    }

    void ResetPower()
    {
        currentPowerAmount = maxPowerAmount;
    }

    public void UsePower(int powerToUse)
    {
        currentPowerAmount -= powerToUse;
        if(currentPowerAmount < 0)
        {
            StartBlowOut();
        }
    }

    void StartBlowOut()
    {
        canUsePower = false;
        blowoutTimePassed = 0f;
    }

    void BlowOut()
    {
        if (!canUsePower)
        {
            blowoutTimePassed += Time.deltaTime;
            if(blowoutTimePassed > blowoutTime)
            {
                EnablePower();
            }
        }
    }

    void EnablePower()
    {
        canUsePower = true;
    }
}
