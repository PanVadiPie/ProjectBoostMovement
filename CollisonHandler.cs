using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] float timeDelay;

     void Start()
    {
         
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You bumped into a friendly object");
                break;

            case "Finish":
                FinishSequence();
                break;

            default:
                CrashSequence();
                break;

        }
    }

    void CrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("SceneReload", timeDelay);
    }
    void FinishSequence()
    {
        Invoke("NextLevel", timeDelay);
        GetComponent<Movement>().enabled = false;
    }
     
    void SceneReload()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex ==  SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
