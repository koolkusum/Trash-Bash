using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : Collectible
{
   public int waterPoints=5;
    protected override void OnCollect()
    {
        if(!collected)
        {

            collected=true;
            GameManager.instance.ShowText("+5 points for recycling",40, Color.yellow, transform.position,Vector3.up*25,2.0f);
            GameManager.instance.points+=waterPoints;
            Debug.Log("Gain +" +waterPoints +" points");

            Destroy(this.gameObject);
            
        }
        //collected=true
        // base.OnCollect();
        // Debug.Log("Gain +5 points");
    }
}
