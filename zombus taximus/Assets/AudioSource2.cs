using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource2 : MonoBehaviour
{
    private static AudioSource2 _instance;

    public static AudioSource2 instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioSource2>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            Debug.Log("audio is live");
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void Play()
    {
        Debug.Log("music playing");
        //Play some audio!
    }
}