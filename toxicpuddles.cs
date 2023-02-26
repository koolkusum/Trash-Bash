using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxicpuddles : Collectible
{
    public int wastePoints=-3;
    protected override void OnCollect()
    {
        if(!collected)
        {

            collected=true;
            GameManager.instance.ShowText("-3 for stepping on toxic waste",40, Color.red, transform.position,Vector3.up*25,2.0f);
            GameManager.instance.points-=wastePoints;
            Debug.Log("Gain +" +wastePoints +" points");

            //Destroy(this.gameObject);
            
        }
        //collected=true
        // base.OnCollect();
        // Debug.Log("Gain +5 points");
    }
}
