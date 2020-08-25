using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    void Update()
    {
        foreach (Transform child in transform)
        {
            AudioSource audio = child.GetComponent<AudioSource>();
            if (!audio.isPlaying)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
