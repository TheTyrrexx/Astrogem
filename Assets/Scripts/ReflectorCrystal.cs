using System;
using System.Collections;
using UnityEngine;

public class ReflectorCrystal : AsteroidPiece
{
  private AudioSource audioSource;
  public AudioClip energyDrainFx;

  void Start()
  {
    base.Start();
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D c)
  {
    // Get the Layer name
    var layerName = LayerMask.LayerToName(c.gameObject.layer);

    if(layerName == "Bullet")
    {
      audioSource.PlayOneShot(energyDrainFx);
      expand();
    }

    if(layerName == "Player")
    {
      audioSource.PlayOneShot(energyDrainFx);
    }
  }

  private void expand()
  {
    if(gameObject.transform.localScale.x < 2.0f && gameObject.transform.localScale.y < 2.0f)
    {
      gameObject.transform.localScale += new Vector3(0.25f, 0.25f, 0.0f);
    }
  }
}
