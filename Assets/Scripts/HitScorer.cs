using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScorer : MonoBehaviour
{
    int hits = 0;
    bool isTransitioning = false;
    void Start()
    {
        
    }

    
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }

      switch (other.gameObject.tag)
      {
        case "Friendly":
            
            break;

        case "Finish":
            
            break;

        default:
            HitCount();
            return;
      }
    }

    void HitCount()
    {
      hits++;
      Debug.Log("you have hit somthing this many times:" + hits);
    }
}
