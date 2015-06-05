using UnityEngine;
using System;
using System.Collections;

//Base "obstacle" class that drops. Used to define general falling behavior.
public class AsteroidPiece : MonoBehaviour
{
  //General Properties
  public bool isAlive = true;
  public bool isSolid = true;

  //Movement Variables
  protected System.Random rand;
  private float xSpeed = 0.0f; //Default Value
  private float ySpeed = -0.00375f; //Default Value
  private float randSpeedMod;
  private float multiSpeedMod;
  public Vector2 startForce;

  //"Spin" Variables
  public bool addTorque =  true;
  public float torqueForce;
  public int torqueDir;

	// Use this for initialization
	public void Start ()
  {
    isAlive = true;
    isSolid = true;
    rand = new System.Random(Guid.NewGuid().GetHashCode());
    randSpeedMod = (float)rand.NextDouble()/10.0f;
    multiSpeedMod = 0.3f;

    //Only take default startForce if not set in Inspector.
    if(startForce.x == 0 && startForce.y == 0)
      startForce = new Vector2(xSpeed, ySpeed - (randSpeedMod * multiSpeedMod));

    this.transform.GetComponent<Rigidbody2D>().AddForce(startForce * Time.deltaTime);

    if(addTorque)
    {
      torqueForce = (float)rand.NextDouble() * 20.0f;
      torqueDir = rand.Next(0, 2);

      if (torqueDir == 0)
        this.transform.GetComponent<Rigidbody2D>().AddTorque(torqueForce);

      if (torqueDir == 1)
        this.transform.GetComponent<Rigidbody2D>().AddTorque(- torqueForce);
    }
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      Time.timeScale = 1.0f;

      //Kill if not alive anymore
      if (!isAlive)
      {
        //Debug.Log("Killing");
        Destroy(gameObject);
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
  }
}
