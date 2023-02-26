using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : Collectible
{
      protected override void OnCollect()
    {
        if(!collected)
        {

            collected=true;
            GameManager.instance.ShowText("Welcome to TrashBash! Recycle and pick up litter to gain points, but beware of the evil Trash Bosses and the toxic waste puddles. ",90, Color.blue, transform.position,Vector3.zero,8.0f);

            Destroy(this.gameObject);
            
        }
    }
}
