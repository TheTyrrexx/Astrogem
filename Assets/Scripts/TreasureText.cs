using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureText : MonoBehaviour
{
  public static int treasure;
  Text treasureTxt;

  // Use this for initialization
  void Start ()
  {
    treasureTxt = GetComponent<Text>();
    treasure = 0;
  }

  // Update is called once per frame
  void Update ()
  {
    if(!GlobalVariables.isPaused)
    {
      Player p = FindObjectOfType<Player>() as Player;
      treasure = p.treasureScore;
      treasureTxt.text = treasure.ToString();
    }
  }
}
