/**
** Author: Tyrrexx
** Project: Stardriver
**/
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
  public float speed = 0.75f;
  public float lifeTime = 5.0f;
  public int power = 1;
  public bool isAlive = true;
  public bool isReflected = false;
  public Vector2 dirVelocity;

  // Use this for initialization
  void Start()
  {
    dirVelocity = new Vector2(0, 1) * speed;
    GetComponent<Rigidbody2D>().velocity = dirVelocity;
    Destroy(gameObject, lifeTime);
  }

  // Update is called once per frame
  void Update()
  {
    if(!GlobalVariables.isPaused)
    {
      if (isAlive == false) Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D c)
  {
    var layerName = LayerMask.LayerToName(c.gameObject.layer);

    if(layerName == "ReflectorCrystal")
    {
      isAlive = false;
    }
    if(layerName == "Rocks")
    {
      isAlive = false;
    }
    if(layerName == "Unbreakium")
    {
      isAlive = false;
    }
  }

  void reflectLaser(Vector2 curVelocity)
  {
    isReflected = true;
    dirVelocity = curVelocity * (speed/2);
    GetComponent<Rigidbody2D>().velocity = dirVelocity;
  }
}