using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GemScoreText : MonoBehaviour
{
  Text treasureTxt;

  // Use this for initialization
  void Start ()
  {
    treasureTxt = GetComponent<Text>();
  }

  // Update is called once per frame
  void Update ()
  {
    treasureTxt.text = GlobalVariables.finalGemsCollected.ToString();
  }
}
