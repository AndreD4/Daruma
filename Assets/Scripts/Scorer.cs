using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{ 
    int hits = 0;
    void OnCollisionEnter(Collision other)
    {
      hits++;
      Debug.Log("you have bumped into something this many times:" + hits);
    }
}
