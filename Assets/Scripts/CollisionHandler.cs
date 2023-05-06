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
    int hits = 0;

   

    bool isTransitioning = false;
    
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      
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
        default:
            StartCrashSequence();
            break;
      }
    }
    

     void StartFinishSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(finish);
      finishParticles.Play();
      GetComponent<Movement>().enabled = false;
      Invoke("LoadNextLevel", waitForNextLevel);
    }
    
    void StartCrashSequence()
    {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(crash);
      crashParticles.Play();
      hits++;
      Debug.Log("You have hit an something this many times:" + hits);
      GetComponent<Movement>().enabled = false;
      Invoke("ReloadLevel", crashDelay);
      
    }
    //Deleted scorer Script added code to CollisionHandler Succsess
    //printing out hit score into console log success
    //want to print out score result after level finished
    //and keep track of the score for each level
    //at the end of the game print out total hit score
    
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
