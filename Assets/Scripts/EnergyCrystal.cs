using UnityEngine;
using System.Collections;

public class EnergyCrystal : AsteroidPiece
{
  public int energyValue = 5;

  private AudioSource audioSource;
  public AudioClip pickupFx;

  void Start()
  {
    base.Start();
    audioSource = GetComponent<AudioSource>();
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
        Destroy(gameObject, pickupFx.length);
      }
      this.transform.GetComponent<Rigidbody2D>().AddForce(startForce * Time.deltaTime);
    }
    if(GlobalVariables.isPaused)
    {
      Time.timeScale = 0.0f;
    }
  }

  void OnTriggerExit2D(Collider2D c)
  {
    var layerName = LayerMask.LayerToName(c.gameObject.layer);

    // Return immediately if the layer is deadzone, only want to delete when going out.
    if (layerName == "DeadZone") Destroy(gameObject);
    else if(layerName == "Player")
    {
      audioSource.PlayOneShot(pickupFx);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.GetComponent<CircleCollider2D>().enabled = false;
      isAlive = false;
    }
  }

}
