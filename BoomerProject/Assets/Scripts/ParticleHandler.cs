using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    void Update()
    {
        foreach (Transform child in transform)
        {
            ParticleSystem particle = child.GetComponent<ParticleSystem>();
            if (!particle.isPlaying)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
