using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopTime : PowerUps
{

    public override void ActivatePickUp()
    {
        //Get all of the enemies and store them in an array
        GameObject[] badguys = GameObject.FindGameObjectsWithTag("Enemy");
        //Set each enemy's speed to 0
        foreach(GameObject badguy in badguys)
        {
            badguy.GetComponent<Enemy>().speed = 0;
        }
        //Start a coroutine that will wait, then reset the speed.
        StartCoroutine(StopSpeed());
    }

    private IEnumerator StopSpeed()
    {
        yield return new WaitForSeconds(5);

        GameObject[] badguys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject badguy in badguys)
        {
            badguy.GetComponent<Enemy>().speed = 5;
        }
    }
}
