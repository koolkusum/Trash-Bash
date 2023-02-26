using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//monobehavior is something we inherit from

//monobehavior is given by unity
public class Paper : Collectible
{
    public int paperPoints=2;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected=true;
            GameManager.instance.ShowText("+2 points for picking up litter",40, Color.yellow, transform.position,Vector3.up*25,2.0f);
            GameManager.instance.points+=paperPoints;
            Debug.Log("Gain +" +paperPoints +" points");
            Destroy(this.gameObject);

            
        }
        //collected=true
        // base.OnCollect();
        // Debug.Log("Gain +2 points");
    }
    
}
