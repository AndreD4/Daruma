using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{ 
    [SerializeField] float  crashDelay = 1f;
    [SerializeField] float waitForNextLevel = 1f;
    [SerializeField] AudioClip finish;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem finishParticles;
    [SerializeField] ParticleSystem crashParticles;


    AudioSource audioSource;
    Movement myMovement;
    Rigidbody rb;
    // int hits = 0;
    

   
    //int hits = 0; tyring to print out whole numbers

    bool isTransitioning = false;
    
    
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      myMovement = GetComponent<Movement>();
      rb = GetComponent<Rigidbody>();
      
    }

    void OnCollisionEnter(Collision other)
    {
      if (isTransitioning) { return; }

      switch (other.gameObject.tag)
      {
        case "Friendly":
            Debug.Log ("this thing is friendly");
            break;

        case "Finish":
            StartFinishSequence();
            break;
            
        // case "Untagged":
        //     HitCount();
        //     break;

        default:
            StartCrashSequence();
            // HitCount();
            break;
      }
    }

    // void HitCount()
    // {
    //     { 
          
    //     }
    // }
    

     void StartFinishSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(finish);
      finishParticles.Play();
      myMovement.enabled = false;
      Invoke("LoadNextLevel", waitForNextLevel);
    }
    
    void StartCrashSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(crash);
      crashParticles.Play();
      // hits++;
      // Debug.Log("you have hit somthing this many times:" + hits);
      GetComponent<Movement>().enabled = false;
      Invoke("ReloadLevel", crashDelay);
      // if (isTransitioning)
      // {
      //   hits++;
      //   Debug.Log("you have hit somthing this many times:" + hits);
      // }
    
      
    }
    
  ////////////////////////////////////////////////////////
       //I cant decide what to do hahahah
    
    void LoadNextLevel()
    {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      int nextSceneIndex = currentSceneIndex + 1;
      if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
      {
        nextSceneIndex = 0;
      }

      SceneManager.LoadScene(nextSceneIndex);

    }

    void ReloadLevel()
    {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }

}
