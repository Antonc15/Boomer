using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Header("Variables")]
    public int teleportHeight;

    [Header("Objects")]
    public TeleporterChild otherTeleporter;
    public GameObject teleportSound;

    void Start()
    {
        otherTeleporter.parentTeleporter = this;
        otherTeleporter.teleportSound = teleportSound;
    }

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

        if(otherTeleporter != null)
            other.position = otherTeleporter.transform.position + (transform.up * teleportHeight);

        GameObject sound = Instantiate(teleportSound, transform.position, Quaternion.identity);
        sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
    }
}
