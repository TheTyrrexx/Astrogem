using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShotsFiredText : MonoBehaviour
{
  Text shotsTxt;

  // Use this for initialization
  void Start ()
  {
    shotsTxt = GetComponent<Text>();
  }

  // Update is called once per frame
  void Update ()
  {
    shotsTxt.text = GlobalVariables.finalShotsFired.ToString();
  }
}