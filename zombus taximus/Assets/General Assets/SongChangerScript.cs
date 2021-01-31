using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongChangerScript : MonoBehaviour
{
    public AudioClip[] song;
   // public AudioListener listen;
    public AudioSource source;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
       
        source.PlayOneShot(song[i]);
    }

    // Update is called once per frame
    void Update()
    {       
        source.clip = song[i];
        if (Input.GetKeyDown(KeyCode.G))
        {
            i++;
            if (i > 2) i =0;
            source.Stop();
            StartCoroutine(WaitJustOneFramePls());
        }       
    }
    IEnumerator WaitJustOneFramePls()
    {
        yield return new WaitForEndOfFrame();
        source.PlayOneShot(song[i]);
    }
}
