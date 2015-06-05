using UnityEngine;
using System.Collections;
using System;

public class Rock : AsteroidPiece
{
  //Rock properties
  int hp;
  int size;

  //Treasure Prefab
  public Treasure T1;
  public Treasure T2;
  public Treasure T3;
  public Treasure T4;

  //Particles
  public ParticleSystem yellowExplosion;
  public ParticleSystem redExplosion;

  //Number of treasures in rock.
  public int numTreasures;
  private Treasure [] treasures;

  private AudioSource audioSource;
  public AudioClip explosionFx;
  public AudioClip tumbleFx;

	// Use this for initialization
	void Start ()
  {
    base.Start();

    //Randomize number of treasures
    rand = new System.Random(Guid.NewGuid().GetHashCode());
    numTreasures = rand.Next(1,5);
    treasures = null;
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D c)
  {
    // Get the Layer name
    var layerName = LayerMask.LayerToName(c.gameObject.layer);

    if(layerName == "Bullet")
    {
      //Maybe remove this and have it placed somewhere else.
      audioSource.PlayOneShot(tumbleFx);
      releaseTreasure();
      audioSource.PlayOneShot(explosionFx);
      explode();
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.GetComponent<PolygonCollider2D>().enabled = false;
      isAlive = false;
    }
  }

  void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      Time.timeScale = 1.0f;
      //Kill if not alive anymore
      if (!isAlive)
      {
        Debug.Log("Killing");
        Destroy(gameObject, explosionFx.length);
      }
      this.transform.GetComponent<Rigidbody2D>().AddForce(startForce * Time.deltaTime);
    }
    if(GlobalVariables.isPaused)
    {
      Time.timeScale = 0.0f;
    }
  }

  public void explode()
  {
    createParticleInstance(yellowExplosion, this.transform.position);
    createParticleInstance(redExplosion, this.transform.position);
  }

  private ParticleSystem createParticleInstance(ParticleSystem prefab, Vector2 position)
  {
    var newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
    Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
    return newParticleSystem;
  }

  private void releaseTreasure()
  {
    rand = new System.Random(Guid.NewGuid().GetHashCode());
    treasures = new Treasure[numTreasures];

    for(var i = 0; i < numTreasures; i++)
    {
      var color = rand.Next(1,5);
      if(color == 1)
      {
        treasures[i] = (Treasure)Instantiate(T1, new Vector3(0, 0, 0), Quaternion.identity);
      }
      else if(color == 2)
      {
        treasures[i] = (Treasure)Instantiate(T2, new Vector3(0, 0, 0), Quaternion.identity);
      }
      else if(color == 3)
      {
        treasures[i] = (Treasure)Instantiate(T3, new Vector3(0, 0, 0), Quaternion.identity);
      }
      else if(color == 4)
      {
        treasures[i] = (Treasure)Instantiate(T4, new Vector3(0, 0, 0), Quaternion.identity);
      }
      else
      {
        treasures[i] = (Treasure)Instantiate(T1, new Vector3(0, 0, 0), Quaternion.identity);
      }
      treasures[i].name = "Treasure";
      treasures[i].transform.parent = GameObject.Find("Spawner").transform;
      treasures[i].transform.localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
      treasures[i].addExplosiveForce();
    }
  }
}
