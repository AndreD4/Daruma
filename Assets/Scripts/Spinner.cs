using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{   [SerializeField] float xRotate = 1f;
    [SerializeField] float yRotate = 1f;
    [SerializeField] float zRotate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotate,yRotate,zRotate);
    }
}
