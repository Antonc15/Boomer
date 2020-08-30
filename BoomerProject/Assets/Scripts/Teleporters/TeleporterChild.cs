using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterChild : MonoBehaviour
{
    [HideInInspector]
    public Teleporter parentTeleporter;
    [HideInInspector]
    public GameObject teleportSound;
    [HideInInspector]
    public float velocityMultiplier;

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

    void Teleport(Transform other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (parentTeleporter != null)
            other.transform.position = parentTeleporter.transform.position + (Vector3.up * 0.1f);

        rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(rb.velocity.y) * velocityMultiplier, rb.velocity.z);

        GameObject sound = Instantiate(teleportSound, transform.position, Quaternion.identity);
        sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
    }
}
