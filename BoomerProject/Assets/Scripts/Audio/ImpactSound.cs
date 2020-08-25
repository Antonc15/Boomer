using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public GameObject[] sound;
    public int minSoundVelocity;

    float maxVolume;

    private void OnCollisionEnter(Collision col)
    {
        if(col.relativeVelocity.magnitude > minSoundVelocity)
        {
            GameObject soundObject = Instantiate(sound[Random.Range(0,sound.Length)], transform.position, Quaternion.identity);
            soundObject.transform.parent = FindObjectOfType<SoundHandler>().transform;
            maxVolume = soundObject.GetComponent<AudioSource>().volume;
            soundObject.GetComponent<AudioSource>().volume = (col.relativeVelocity.magnitude / minSoundVelocity / 5) * maxVolume;
        }
    }
}
