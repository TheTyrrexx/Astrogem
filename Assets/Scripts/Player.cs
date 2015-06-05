/**
** Author: Tyrrexx
** Project: Stardriver
**/
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
  //Player specific variables
  public bool isAlive = true;
  public int hp = 3;

  //Used to calculate "speed" of travel. Will probably remove.
  public float speed = 5.0f;

  //L and R movement speed.
  public float hSpeed = 50.0f;

  //Remaining energy for shooting and using the tractor beam.
  public int energyTank;
  public int fuelTank;
  public int treasureScore;
  public int shotsFired;
  public bool canShoot = true;
  public bool paused = false;

  //Time needed to decrement fuel
  public float fuelDelay = 1.0f;
  public float fuelTime;
  public bool emptyTank = false;

  //Prefabs tied to the Player
  public GameObject bullet;

  public Sprite playerNormal;
  public Sprite playerLeft;
  public Sprite playerRight;

  private AudioSource audioSource;
  public AudioClip laserFx;
  public AudioClip powerDownFx;

  // Use this for initialization
  void Start ()
  {
    GetComponent<Rigidbody2D>().isKinematic = true;
    energyTank = 10;
    fuelTank = 20;
    GlobalVariables.finalGemsCollected = 0;
    GlobalVariables.finalShotsFired = 0;
    treasureScore = 0;
    shotsFired = 0;
    fuelTime = fuelDelay;
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      //Check alive
      if (!isAlive || emptyTank)
      {
        GlobalVariables.finalGemsCollected = treasureScore;
        GlobalVariables.finalShotsFired = shotsFired;
        audioSource.PlayOneShot(powerDownFx);
        this.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.5f, 0.5f);
        transform.FindChild("Engine1").GetComponent<SpriteRenderer>().enabled = false;
        transform.FindChild("Engine2").GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(loadScoreScreen());
      }
      if(isAlive && !emptyTank)
      {
        movePlayer();

        //Shoot a bullet
        if (Input.GetKeyDown(KeyCode.Space)) shoot(transform);

        //Reload Level
        if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);

        if (!GlobalVariables.isPaused && Input.GetKeyDown(KeyCode.P))
        {
          GlobalVariables.isPaused = true;
          Debug.Log("Pausing");
        }

        //Manage fuel
        updateFuel();
      }
    }
    else
    {
      if (GlobalVariables.isPaused && Input.GetKeyDown(KeyCode.P))
      {
        GlobalVariables.isPaused = false;
        Debug.Log("Unpausing");
      }
    }
  }

  IEnumerator loadScoreScreen()
  {
    yield return new WaitForSeconds(3);
    Application.LoadLevel("ScoreScene");
  }

  public void movePlayer()
  {
    //New location to send character
    var move = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //Old and New Position
    var oldPos = transform.position;
    var newPos = new Vector2(move.x, transform.position.y);

    var sr = GetComponent<SpriteRenderer>();

    if(newPos.x < oldPos.x)
    {
      sr.sprite = playerLeft;
    }
    else if(newPos.x > oldPos.x)
    {
      sr.sprite = playerRight;
    }
    else
    {
      sr.sprite = playerNormal;
    }

    transform.position = new Vector2(move.x, transform.position.y);

    //Clamping code so player cannot move offscreen
    if(Camera.main.WorldToViewportPoint(transform.position).x < 0.0f)
    {
      var view = Camera.main.ViewportToWorldPoint(new Vector2(0.0f, 0.0f));
      transform.position = new Vector2(view.x, transform.position.y);
    }
    else if(Camera.main.WorldToViewportPoint(transform.position).x > 1.0f)
    {
      var view = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
      transform.position = new Vector2(view.x, transform.position.y);
    }

    GetComponent<Rigidbody2D>().position = transform.position;
  }

  //Checks collisions
  void OnTriggerEnter2D(Collider2D c)
  {
    var layerName = LayerMask.LayerToName(c.gameObject.layer);

    if (layerName == "Unbreakium")
    {
      isAlive = false;
    }

    if(layerName == "Rocks")
    {
      isAlive = false;
    }

    if(layerName == "ReflectorCrystal")
    {
      energyTank -= 5;
      fuelTank -= 3;
    }

    if (layerName == "Treasure")
    {
      var treasure = c.gameObject.GetComponent<Treasure>();
      Debug.Log("Treasure value: " + treasure.value);
      treasureScore += treasure.value;
    }

    if(layerName == "EnergyCrystal")
    {
      energyTank += c.gameObject.GetComponent<EnergyCrystal>().energyValue;
      if(energyTank > 20)
        energyTank = 20;
    }

    if(layerName == "Fuel")
    {
      fuelTank += c.gameObject.GetComponent<FuelCrystal>().fuelValue;
      if(fuelTank > 20)
        fuelTank = 20;
    }

  }

  //Moves the ship left or right
  public void move(string direction)
  {
    // Get the lower-left world coordinate of the viewport.
    //Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    Vector2 min = Camera.main.GetComponent<Camera>().ViewportToWorldPoint(new Vector2(0, 0));

    // Get the upper-right world coordinate of the viewport.
    //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    Vector2 max = Camera.main.GetComponent<Camera>().ViewportToWorldPoint(new Vector2(1, 1));

    // Get the coordinates of the player
    Vector2 pos = transform.position;

    if(direction == "L" && pos.x > min.x)
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * hSpeed;
    }
    if(direction == "R" && pos.x < max.x)
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * hSpeed;
    }

    transform.position = new Vector2(
      Mathf.Clamp(pos.x, min.x, max.x),
      Mathf.Clamp(pos.y, min.y, max.y)
    );
  }

  //Shoots a bullet to kill a mine.
  public void shoot(Transform origin)
  {
    if(energyTank >= 1)
    {
      Debug.Log("Shooting");
      Instantiate(bullet, origin.position, origin.rotation);
      audioSource.PlayOneShot(laserFx);
      energyTank -= 1;
      shotsFired++;
    }
    else
      return; //Flash red or something
  }

  //Ship crashes decrement hp and start invincibility.
  public void crash()
  {
    hp -= 1;
    if (hp <= 0) gameOver();
  }

  public void gameOver()
  {
    isAlive = false;
  }

  //Updates current speed to make the game harder
  public void updateSpeed(float dist)
  {
    //Not exact algorithm but something like this should happen.
    if (dist > 10000.0)
    {
      speed += 1;
    }
  }

  //Managing Fuel
  public void updateFuel()
  {
    if(fuelTime > 0.0f)
    {
      fuelTime -= Time.deltaTime;
    }

    if(fuelTime <= 0.0f)
    {
      fuelTank--;
      fuelTime = fuelDelay;
    }

    if(fuelTank <= 0)
    {
      emptyTank = true;
    }
  }
}