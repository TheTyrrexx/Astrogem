using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyText : MonoBehaviour
{
  public static int energy;
  Text energyTxt;

	// Use this for initialization
	void Start ()
  {
	  energyTxt = GetComponent<Text>();
    energy = 0;
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      Player p = FindObjectOfType<Player>() as Player;
      energy = p.energyTank;
      energyTxt.text = energy.ToString();
    }
	}
}
