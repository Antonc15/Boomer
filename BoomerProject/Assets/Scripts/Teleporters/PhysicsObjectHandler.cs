using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjectHandler : MonoBehaviour
{
    void Update()
    {
        foreach(Transform child in transform)
        {
            LiveTime timer = child.GetComponent<LiveTime>();

            if(timer!= null && timer.liveTime < Time.time)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
