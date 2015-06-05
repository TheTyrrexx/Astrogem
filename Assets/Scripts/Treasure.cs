/**
** Author: Tyrrexx
** Project: Stardriver
**/
using UnityEngine;
using System.Collections;
using System;

public class Treasure : AsteroidPiece
{
  //can be S, M, L or 0, 1, 2.
  public int type;
  public int value = 1;
  public float explForceY = 0.025f;  //Strength shooting up when exploding out of rock object.
  public bool isBeingSucked;
  private AudioSource audioSource;
  public AudioClip gemPickupFx;


  // Use this for initialization
  void Start ()
  {
    base.Start();
    audioSource = GetComponent<AudioSource>();
    isBeingSucked = false;

    if(explForceY == 0.0f)
      explForceY = 0.025f;
  }

  public void addExplosiveForce()
  {
    rand = new System.Random(Guid.NewGuid().GetHashCode());
    var xForceBase = rand.Next(-3, 3);
    var modx = rand.NextDouble()/100f;
    var mody = rand.NextDouble()/100f;
    Debug.Log("ModX: " + modx + "   ModY: " + mody);

    //var force = new Vector2((xForceBase - 2)/100f + (float)modx, explForceY + (float)(mody));
    var force = new Vector2(xForceBase/100f + (float)modx, explForceY + (float)(mody));
    this.transform.GetComponent<Rigidbody2D>().AddForce(force);
  }

  // Update is called once per frame
  void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      //Need to delete outside of collider to keep scoring working.
      if (isAlive == false)
      {
        Destroy(gameObject, gemPickupFx.length);
      }

      //Pull down harder when its treasure.
      this.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, - 0.05f * Time.deltaTime));
    }
  }

  void OnTriggerEnter2D(Collider2D c)
  {
    string layerName = LayerMask.LayerToName(c.gameObject.layer);

    // Return immediately if the layer is deadzone, only want to delete when going out.
    if (layerName == "Player")
    {
      audioSource.PlayOneShot(gemPickupFx, 3.0f);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.GetComponent<CircleCollider2D>().enabled = false;
      isAlive = false;
    }
  }
}