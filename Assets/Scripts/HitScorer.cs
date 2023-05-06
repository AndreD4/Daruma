using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScorer : MonoBehaviour
{
    int hits = 0;
    void Start()
    {
        
    }

    
    void OnCollisionEnter()
    {
        hits++;
        Debug.Log("You have hit an something this many times:" + hits);
    }
}
