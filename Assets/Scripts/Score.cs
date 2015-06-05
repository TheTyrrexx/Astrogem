/**
** Author: Tyrrexx
** Project: Stardriver
**/
using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
  public int totalTreasure;
  public int totalTreasurePieces;

  // Use this for initialization
  void Start()
  {
    init();
  }

  // Update is called once per frame
  void Update()
  {}

  void init()
  {
    totalTreasure = 0;
    totalTreasurePieces = 0;
  }

  public void updateTreasureScore(int score)
  {
    totalTreasurePieces += 1;
    totalTreasure += score;
  }
}