using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    //public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        //GameManager.instance.ShowText();
        if(coll.name=="Player")
        {
            //teleport the player
            GameManager.instance.SaveState();
            //string sceneName=sceneNames[Random.Range(0,sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene("Dungeon1");

        }
    }
}
