using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FuelText : MonoBehaviour
{
  public static int fuel;
  Text fuelTxt;

  // Use this for initialization
  void Start ()
  {
    fuelTxt = GetComponent<Text>();
    fuel = 0;
  }

  // Update is called once per frame
  void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      Player p = FindObjectOfType<Player>() as Player;
      fuel = p.fuelTank;
      fuelTxt.text = fuel.ToString();
    }
  }
}
