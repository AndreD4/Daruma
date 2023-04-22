using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustPower = 1f;
    [SerializeField] float rotationPower = 1f;
    [SerializeField] AudioClip mainJump;
    Rigidbody myRigidbody;
    AudioSource audioSource;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProccessThrust();
        ProccessRotation();
    }

    void ProccessThrust()
    {
      if (Input.GetKey(KeyCode.Space))
      {
        myRigidbody.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        if(!audioSource.isPlaying)
        {
        audioSource.PlayOneShot(mainJump);
        } 
      }
      else
      {
        audioSource.Stop();
      }
    }

    void ProccessRotation()
    {
      if (Input.GetKey(KeyCode.A))
    {
      ApplyRotation(-rotationPower);
    }

    else if (Input.GetKey(KeyCode.D))
      {
          ApplyRotation(rotationPower);
      }
    }

    void ApplyRotation(float rotationThisFrame)
  {
    myRigidbody.freezeRotation = true; // freezing rotation so i can manually rotate
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    myRigidbody.freezeRotation = false; // unfreezing rotation so the physics system can take over

  }
}
