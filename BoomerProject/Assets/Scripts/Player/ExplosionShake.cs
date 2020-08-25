using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionShake : MonoBehaviour
{
    float shakeTimeRemaining;
    float shakePower;
    float shakeFadeTime;
    float shakeRotation;
    float rotationMultiplier;

    Vector3 startPosition;
    Quaternion startRotation;

    void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (shakeTimeRemaining <= 0)
        {
            transform.localPosition = startPosition;
            transform.localRotation = startRotation;
        }
        else if (shakeTimeRemaining > 0)
        {
            transform.localPosition = startPosition;
            transform.localRotation = startRotation;

            shakeTimeRemaining -= Time.deltaTime;

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.localPosition += new Vector3(xAmount, yAmount, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1, 1f));
        }
    }

    public void StartShake(float length, float power, float rotationAmount)
    {
        rotationMultiplier = rotationAmount;

        shakeTimeRemaining = length;

        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;
    }
}
