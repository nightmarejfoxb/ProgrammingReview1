using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nopain : PowerUps
{
    public override void ActivatePickUp()
    {
        //Get all of the enemies and store them in an array
        GameObject[] badguys = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject badguy in badguys)
        {
            badguy.GetComponent<Collider2D>().enabled = false;
        }
        //Start a coroutine that will wait, then reset the speed.
        StartCoroutine(hurtdely());
    }

    private IEnumerator hurtdely()
    {
        yield return new WaitForSeconds(5);

        GameObject[] badguys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject badguy in badguys)
        {
            badguy.GetComponent<Collider2D>().enabled = true;
        }
    }

}
