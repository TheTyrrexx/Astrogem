using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour
{
  public Text pauseText;

	// Use this for initialization
	void Start ()
  {
    pauseText = GetComponent<Text>();
    pauseText.enabled = false;
	}

	// Update is called once per frame
	void Update ()
  {
    if(GlobalVariables.isPaused)
    {
      pauseText.enabled = true;
    }
    else if(!GlobalVariables.isPaused)
    {
      pauseText.enabled = false;
    }
  }
}
