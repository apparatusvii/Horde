using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LevelLoaderTimer : MonoBehaviour
{
    public float loadingDelay = 0;
    public LevelLoader levelLoader;
    // Start is called before the first frame update

    
    public void StartTimer()
    {
        levelLoader.LoadNextLevel();
    }
}
