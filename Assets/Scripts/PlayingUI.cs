using UnityEngine;
using System.Collections;

public class PlayingUI : MonoBehaviour
{
  Player player;
  public string energyText;

	// Use this for initialization
	void Start ()
  {
    player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
  {

	}
}
