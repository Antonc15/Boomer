using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{

    public float boostStrength;
    public float maxBoostHeight;

    public GameObject boostSound;

    void Start()
    {
        UpdateTrigger();
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Rigidbody rbParent = other.GetComponentInParent<Rigidbody>();

        if (rb != null)
        {
            GameObject sound = Instantiate(boostSound, transform.position, Quaternion.identity);
            sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
        }

        if (rbParent != null)
        {
            GameObject sound = Instantiate(boostSound, transform.position, Quaternion.identity);
            sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
        }

    }

    private void OnTriggerStay(Collider other)
    {

        Rigidbody rb = other.GetComponent<Rigidbody>();
        Rigidbody rbParent = other.GetComponentInParent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(transform.up * boostStrength);
        }

        if (rbParent != null)
        {
            rbParent.AddForce(transform.up * boostStrength);
        }
    }

    public void UpdateTrigger()
    {
        transform.localScale = new Vector3(transform.localScale.x, maxBoostHeight / 2, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, (maxBoostHeight / 2) + 0.17f, transform.localPosition.z);
    }
}
