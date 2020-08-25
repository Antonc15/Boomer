using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTime : MonoBehaviour
{
    public float liveTime;
    void Awake()
    {
        liveTime = liveTime + Time.time;
    }
}
