using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    //an array of objects collided with in a given frame
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider= GetComponent<BoxCollider2D>();

    }

    protected virtual void Update()
    {
        //putting the collider in the array
        boxCollider.OverlapCollider(filter, hits);
        for(int i = 0; i < hits.Length; i++)
        {
            //nothing in array, add to array
            if(hits[i]==null)
                continue;
            //goes to function to change the content based on
            //the hit
            OnCollide(hits[i]);

            //the array must be cleaned manually
            hits[i]=null;
            

        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("On Collide was not implemented in " +this.name);

    }
}
