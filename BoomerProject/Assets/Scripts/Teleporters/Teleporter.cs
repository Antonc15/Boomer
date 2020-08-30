using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Header("Variables")]
    public float velocityMultiplier;

    [Header("Objects")]
    public TeleporterChild otherTeleporter;
    public GameObject teleportSound;

    void Start()
    {
        AssignChildVariables();
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Rigidbody rbParent = other.GetComponentInParent<Rigidbody>();

        if (rb != null)
        {
            Teleport(other.transform);
        }

        if (rbParent != null)
        {
            Teleport(rbParent.transform);
        }
    }

    void AssignChildVariables()
    {
        otherTeleporter.parentTeleporter = this;
        otherTeleporter.teleportSound = teleportSound;
        otherTeleporter.velocityMultiplier = velocityMultiplier;
    }

    void Teleport(Transform other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        other.transform.position = otherTeleporter.transform.position + (Vector3.up * 0.1f);

        rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y) * velocityMultiplier, rb.velocity.z);

        GameObject sound = Instantiate(teleportSound, transform.position, Quaternion.identity);
        sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
    }
}
