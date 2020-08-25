using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterChild : MonoBehaviour
{
    [HideInInspector]
    public Teleporter parentTeleporter;
    [HideInInspector]
    public GameObject teleportSound;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Rigidbody rbParent = other.GetComponentInParent<Rigidbody>();

        UsedTeleporterTag used = other.GetComponent<UsedTeleporterTag>();
        UsedTeleporterTag usedParent = other.GetComponentInParent<UsedTeleporterTag>();

        if (rb != null && used == null)
        {
            Teleport(other.transform);
        }

        if (rbParent != null && usedParent == null)
        {
            Teleport(rbParent.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UsedTeleporterTag used = other.GetComponent<UsedTeleporterTag>();
        UsedTeleporterTag usedParent = other.GetComponentInParent<UsedTeleporterTag>();

        if (used != null)
        {
            Destroy(used);
        }

        if (usedParent != null)
        {
            Destroy(usedParent);
        }
    }

    void Teleport(Transform other)
    {
        UsedTeleporterTag used = other.gameObject.AddComponent<UsedTeleporterTag>();

        if (parentTeleporter != null)
            other.transform.position = parentTeleporter.transform.position + (transform.up * parentTeleporter.teleportHeight);

        GameObject sound = Instantiate(teleportSound, transform.position, Quaternion.identity);
        sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
    }
}
