using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{ 
    int hits = 0;
    void OnCollisionEnter(Collision other)
    {

      switch (other.gameObject.tag)
      {
        case "Friendly":
            
            break;

        case "Finish":
            
            break;
        default:
            HitCount();
            break;
      }
    }

    void HitCount()
    {
      hits++;
      Debug.Log("You have hit an something this many times:" + hits);
    }
}
