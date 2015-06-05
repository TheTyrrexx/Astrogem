/**
** Author: Tyrrexx
** Project: Stardriver
**/
using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {}

  // Update is called once per frame
  void Update ()
  {}

  void OnTriggerExit2D(Collider2D c)
  {
    Destroy(c.gameObject);
  }
}