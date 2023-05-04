using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{ 
    int hits = 0;
    void OnCollisionEnter(Collision other)
    { 
      if (other.gameObject.tag != "Friendly" + "Finish")
      {
        hits++;
        Debug.Log("you have bumped into something this many times:" + hits);
      }
      
    }
}
