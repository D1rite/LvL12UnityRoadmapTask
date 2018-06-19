using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioClip[] clips;
    public AudioSource AS;
    // Use this for initialization

    public void PlayClip(int clip)
    {
        AS.PlayOneShot(clips[clip]);
    }
}
