using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongChangerScript : MonoBehaviour
{
    public AudioClip[] song = new AudioClip[3];
  
    public AudioSource source;
 
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
   


        
    }

    void AudioRotation()
    {
     
    }
}
