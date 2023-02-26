using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code sets up a box collider on the object that is attached to the gameobject
//it also sets up movement and flipping the sprite based on the direction of movement
//there is no physics 
public class Player : Mover
{ 
  private SpriteRenderer spriteRenderer;

  protected override void Start()
  {
    base.Start();
    spriteRenderer = GetComponent<SpriteRenderer>();

    DontDestroyOnLoad(gameObject);
  }
  private void FixedUpdate()
{
   float x = Input.GetAxisRaw("Horizontal");
   float y = Input.GetAxisRaw("Vertical");
   UpdateMotor(new Vector3(x, y, 0));
}

        
}
