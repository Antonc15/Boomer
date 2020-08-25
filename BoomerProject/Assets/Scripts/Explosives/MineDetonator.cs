using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetonator : MonoBehaviour
{
    [Header("Cam Shake")]
    public float shakeMagnitude;
    public float shakeDuration;
    public float rotationMultiplier;


    public GameObject explosionObject;
    public Transform player;

    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                MineTime mineTime = child.GetComponent<MineTime>();

                if (mineTime.spawnTime < Time.time)
                {
                    mineTime.Explode();

                    // Handle the ringing sound \/

                    float dist = Vector3.Distance(player.position, child.position);

                    if(dist <= mineTime.explosionFeelDistance)
                    {
                        //Audio
                        player.GetComponentInChildren<AudioLowPassFilter>().cutoffFrequency = 1000;

                        FindObjectOfType<ExplosionShake>().StartShake(shakeDuration, shakeMagnitude, rotationMultiplier);
                    }
                }
            }
        }
    }
}
