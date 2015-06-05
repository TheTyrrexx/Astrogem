using UnityEngine;
using System.Collections;

public class TractorBeam : MonoBehaviour
{
	//Determines if tractor beam will be displaying and "sucking"
  public bool isActive;

	// Use this for initialization
	void Start ()
  {
    isActive = false;
	}
	
	// Update is called once per frame
	void Update ()
  {
    if(isActive)
    {
      //Display and suck some stuff
      GetComponent<Renderer>().enabled = true;
    }
    else
      GetComponent<Renderer>().enabled = false;
	}
}
