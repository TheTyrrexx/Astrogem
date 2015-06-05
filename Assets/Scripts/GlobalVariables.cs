using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour
{
  public static bool isPaused;
  public static int finalGemsCollected;
  public static int finalShotsFired;

	// Use this for initialization
	void Start ()
  {
	  isPaused = false;
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(!GlobalVariables.isPaused) {}
	}
}
