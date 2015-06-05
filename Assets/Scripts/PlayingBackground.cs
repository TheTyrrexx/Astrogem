/**
** Author: Tyrrexx
** Project: Stardriver
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rename class
public class PlayingBackground : MonoBehaviour
{
  //Scrolling speed
  public Vector2 speed = new Vector2(0.0f, 0.05f);
  public Vector2 direction = new Vector2(0, -1);
  public Vector2 start = new Vector2(0.0f, 16f);
  public bool isLooping = false;

  // Use this for initialization
  void Start()
  {
  }

  void Update()
  {
    if(!GlobalVariables.isPaused)
    {
      if (gameObject.transform.position.y <= - 16f) {
        if (gameObject.name == "Stars1") {
          var bgStars2Pos = GameObject.Find("Stars2").gameObject.transform.position;
          bgStars2Pos.y += 16f;
          gameObject.transform.position = bgStars2Pos;
        }
        if (gameObject.name == "Stars2") {
          var bgStars1Pos = GameObject.Find("Stars1").gameObject.transform.position;
          bgStars1Pos.y += 16f;
          gameObject.transform.position = bgStars1Pos;
        }

      }
      // Movement
      var movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
      movement *= Time.deltaTime;
      transform.Translate(movement);
    }
  }
}