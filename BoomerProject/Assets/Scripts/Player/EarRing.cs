using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarRing : MonoBehaviour
{

    public AudioLowPassFilter audioFilter;
    public float muffleDecayAmount;

    void Update()
    {
        MuffleChange();
    }

    void MuffleChange()
    {
        if(audioFilter.cutoffFrequency < 22000)
        {
            audioFilter.cutoffFrequency = Mathf.Lerp(audioFilter.cutoffFrequency, 22000, muffleDecayAmount * Time.deltaTime);
        }
    }
}
