using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : Mover
{
    //Experience
    public int xpValue=1;

    //logic
    public float triggerLength=1;
    public float chaseLength=8;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //hitbox
    private BoxCollider2D hitbox;
    private Collider2D[] hits= new Collider2D[10];
    public ContactFilter2D filter;

    protected override void Start()
    {
        base.Start();
        
        //boxCollider=GetComponent<BoxCollider2D>();
        playerTransform=GameManager.instance.player.transform;
        startingPosition=transform.position;
        hitbox= transform.GetChild(0).GetComponent<BoxCollider2D>();

    }
    private void FixedUpdate()
    {
        //is the player in range?
        //in between starting position and chase
        if (Vector3.Distance(playerTransform.position, startingPosition)<chaseLength)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition)<triggerLength)
            {
                chasing=true;
            }
            
            if(chasing)
            {
                if(!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position- transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition-transform.position);
                
            }
        }
        else
        {
            UpdateMotor(startingPosition-transform.position);
            chasing=false;
            
        }
        //checking for overlap
        collidingWithPlayer=false;

         boxCollider.OverlapCollider(filter, hits);
        for(int i = 0; i < hits.Length; i++)
        {
            //nothing in array, add to array
            if(hits[i]==null)
                continue;
            //goes to function to change the content based on
            //the hit
            if(hits[i].tag=="Fighter"&&hits[i].name=="Player")
            {
                collidingWithPlayer=true;
                
            }

            //the array must be cleaned manually
            hits[i]=null;
            

        }

        
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience+=xpValue;
        GameManager.instance.ShowText("+"+xpValue +" xp",30, Color.magenta, transform.position, Vector3.up*40,1.5f);

        
    }

}
