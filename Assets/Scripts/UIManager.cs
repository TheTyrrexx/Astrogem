using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
  {
	
	}

  public void showMainMenu()
  {
    Application.LoadLevel("MenuScene");
  }

  public void startGame()
  {
    Application.LoadLevel("PlayScene");
  }

  public void showHowToPlay()
  {
    Application.LoadLevel("HTPScene");
  }

  public void quit()
  {
    Application.Quit();
  }
}
