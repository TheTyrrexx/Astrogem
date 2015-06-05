using System;
using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
  //Item Prefabs
  //Rock Prefabs
  public Rock R1;
  public Rock R2;
  public Rock R3;
  public Rock R4;
  public Rock R5;
  public Rock R6;

  //Unbreakium Prefabs
  public Unbreakium U1;
  public Unbreakium U2;
  public Unbreakium U3;
  public Unbreakium U4;
  public Unbreakium U5;
  public Unbreakium U6;

  public ReflectorCrystal F;
  public EnergyCrystal E;
  public FuelCrystal G;

  //Spawning variables
  float timeLastObj;
  float spawnDelay;
  float spawnPosX;
  float spawnPosY;
  float spawnSpeedY;
  Vector2 spawnDir;
  bool spawnNewObj;

  System.Random rand;

	// Use this for initialization
	void Start ()
  {
    rand = new System.Random(Guid.NewGuid().GetHashCode());
    timeLastObj = 0.0f;
    spawnDelay = 0.35f;
    spawnPosX = 0.0f;
    spawnPosY = 0.0f;
    spawnNewObj = true;
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      if (timeLastObj >= spawnDelay) {
        timeLastObj = 0.0f;
        var spawnType = rand.Next(1, 11);
        createNewObject(spawnType);
        //Will probably be random or based on difficulty.
        spawnDelay = 0.20f;
      }
      timeLastObj += Time.deltaTime;
    }
	}

  void createNewObject(int type)
  {
    Debug.Log(type);
    //Get random starting X position.
    spawnPosX = rand.Next(-42, 42)/10.0f;
    spawnPosY = 0.0f;

    if(type == 1 || type == 4 || type == 8 || type == 7)
    {
      rand = new System.Random(Guid.NewGuid().GetHashCode());
      var num = rand.Next(1, 7);
      if(num == 1)
      {
        Unbreakium newUnb = (Unbreakium)Instantiate(U1, new Vector3(0, 0, 0), Quaternion.identity);
        newUnb.name = "Unbreakium1";
        newUnb.transform.parent = GameObject.Find("Spawner").transform;
        newUnb.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 2)
      {
        Unbreakium newUnb = (Unbreakium)Instantiate(U2, new Vector3(0, 0, 0), Quaternion.identity);
        newUnb.name = "Unbreakium2";
        newUnb.transform.parent = GameObject.Find("Spawner").transform;
        newUnb.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 3)
      {
        Unbreakium newUnb = (Unbreakium)Instantiate(U3, new Vector3(0, 0, 0), Quaternion.identity);
        newUnb.name = "Unbreakium3";
        newUnb.transform.parent = GameObject.Find("Spawner").transform;
        newUnb.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 4)
      {
        Unbreakium newUnb = (Unbreakium)Instantiate(U4, new Vector3(0, 0, 0), Quaternion.identity);
        newUnb.name = "Unbreakium4";
        newUnb.transform.parent = GameObject.Find("Spawner").transform;
        newUnb.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 5)
      {
        Unbreakium newUnb = (Unbreakium)Instantiate(U5, new Vector3(0, 0, 0), Quaternion.identity);
        newUnb.name = "Unbreakium5";
        newUnb.transform.parent = GameObject.Find("Spawner").transform;
        newUnb.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 6)
      {
        Unbreakium newUnb = (Unbreakium)Instantiate(U6, new Vector3(0, 0, 0), Quaternion.identity);
        newUnb.name = "Unbreakium6";
        newUnb.transform.parent = GameObject.Find("Spawner").transform;
        newUnb.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
    }
    if(type == 2 || type == 3 || type == 6)
    {
      rand = new System.Random(Guid.NewGuid().GetHashCode());
      var num = rand.Next(1, 7);
      if(num == 1)
      {
        Rock newRock = (Rock)Instantiate(R1, new Vector3(0, 0, 0), Quaternion.identity);
        newRock.name = "Rock1";
        newRock.transform.parent = GameObject.Find("Spawner").transform;
        newRock.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 2)
      {
        Rock newRock = (Rock)Instantiate(R2, new Vector3(0, 0, 0), Quaternion.identity);
        newRock.name = "Rock2";
        newRock.transform.parent = GameObject.Find("Spawner").transform;
        newRock.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 3)
      {
        Rock newRock = (Rock)Instantiate(R3, new Vector3(0, 0, 0), Quaternion.identity);
        newRock.name = "Rock3";
        newRock.transform.parent = GameObject.Find("Spawner").transform;
        newRock.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 4)
      {
        Rock newRock = (Rock)Instantiate(R4, new Vector3(0, 0, 0), Quaternion.identity);
        newRock.name = "Rock4";
        newRock.transform.parent = GameObject.Find("Spawner").transform;
        newRock.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 5)
      {
        Rock newRock = (Rock)Instantiate(R5, new Vector3(0, 0, 0), Quaternion.identity);
        newRock.name = "Rock5";
        newRock.transform.parent = GameObject.Find("Spawner").transform;
        newRock.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
      else if(num == 6)
      {
        Rock newRock = (Rock)Instantiate(R6, new Vector3(0, 0, 0), Quaternion.identity);
        newRock.name = "Rock6";
        newRock.transform.parent = GameObject.Find("Spawner").transform;
        newRock.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      }
    }
    if(type == 5)
    {
      ReflectorCrystal newFCry = (ReflectorCrystal)Instantiate(F, new Vector3(0, 0, 0), Quaternion.identity);
      newFCry.name = "ReflectorCrystal";
      newFCry.transform.parent = GameObject.Find("Spawner").transform;
      newFCry.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      //newFCry.setMovement(spawnSpeedY, spawnDir);
    }
    if(type == 9)
    {
      EnergyCrystal newECry = (EnergyCrystal)Instantiate(E, new Vector3(0, 0, 0), Quaternion.identity);
      newECry.name = "EnergyCrystal";
      newECry.transform.parent = GameObject.Find("Spawner").transform;
      newECry.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      //newECry.setMovement(spawnSpeedY, spawnDir);
    }
    if(type == 10)
    {
      FuelCrystal newFuel = (FuelCrystal)Instantiate(G, new Vector3(0, 0, 0), Quaternion.identity);
      newFuel.name = "FuelCrystal";
      newFuel.transform.parent = GameObject.Find("Spawner").transform;
      newFuel.transform.localPosition = new Vector2(spawnPosX, spawnPosY);
      //newECry.setMovement(spawnSpeedY, spawnDir);
    }
  }
}
