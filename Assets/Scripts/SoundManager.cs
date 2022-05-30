using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // _introAudioSrc = transform.Find("Intro").gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void play(string gameObject)
    {
        if (transform.Find(gameObject) is not null )
            transform.Find(gameObject).GetComponent<AudioSource>().Play();
    }

    public void stop(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().Stop();
    }

    public void pause(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().Pause();
    }

    public void unPause(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().UnPause();
    }

}
