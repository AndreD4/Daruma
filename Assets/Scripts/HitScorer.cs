using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScorer : MonoBehaviour
{
    
    int hits = 0;
    void Start()
    {
    //print put whole numbers once when hit into object
    //printing out hit score into console log success
    //Still not working the way i want
    //want to print out score result after level finished
    //and keep track of the score for each level
    //at the end of the game print out total hit score
    }

    void OnCollisionEnter(Collision other)
    {
     if(other.gameObject.tag == "Untagged")

     { 
      hits++;
      Debug.Log("you have hit somthing this many times:" + hits);
      
     }

    }
}
