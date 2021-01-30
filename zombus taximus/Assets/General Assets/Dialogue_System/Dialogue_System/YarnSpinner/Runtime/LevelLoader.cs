using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
public class LevelLoader : MonoBehaviour
{
    public string sceneToLoad;
    public Animator transition;
    public GameObject audioSource;
    public float startDelay;
    public float transitionTime;

    [YarnCommand("LoadLevel")]
    public void LoadNextLevel()
    {
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(startDelay);
        //Play Animation
        transition.SetTrigger("Start");
        audioSource.SetActive(true);
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
