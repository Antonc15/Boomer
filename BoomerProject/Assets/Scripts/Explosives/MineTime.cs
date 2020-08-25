using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MineTime : MonoBehaviour
{

    public float explosionFeelDistance;
    public int liveTime;
    public int maxDamage;

    [Header("Knockback")]
    public float knockbackRadius;
    public float knockbackStrength;

    [HideInInspector]
    public float spawnTime;

    public GameObject explosionSound;
    public GameObject explosionObject;

    void Start()
    {
        spawnTime = Time.time + liveTime;
        transform.parent = FindObjectOfType<MineDetonator>().transform;
    }

    public void Explode()
    {
        ExplosionSpawner();
        ExplosionKnockback();
        ExplosionDamage();

        Destroy(gameObject);
    }

    void ExplosionSpawner()
    {
        if (explosionObject != null)
        {
            GameObject explosion = Instantiate(explosionObject, transform.position, Quaternion.identity);
            explosion.transform.parent = FindObjectOfType<ParticleHandler>().transform;
        }

        GameObject sound = Instantiate(explosionSound, transform.position, Quaternion.identity);
        sound.transform.parent = FindObjectOfType<SoundHandler>().transform;
    }

    void ExplosionKnockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, knockbackRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponentInParent<Rigidbody>();
            if (rb == null)
                rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(knockbackStrength, transform.position, knockbackRadius, knockbackRadius / 10);
        }
    }

    void ExplosionDamage()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, knockbackRadius);

        foreach (Collider hit in cols)
        {
            BreakableObject hitObject = hit.GetComponentInParent<BreakableObject>();
            WallBreak hitWall = hit.GetComponentInParent<WallBreak>();

            if (hitObject != null)
            {
                float distance = Vector3.Distance(hit.transform.position, transform.position);

                int damage = Mathf.RoundToInt(maxDamage * (knockbackRadius / distance) / knockbackRadius);

                hit.GetComponentInParent<BreakableObject>().TakeDamage(damage);
            }

            if(hitWall != null)
            {
                float distance = Vector3.Distance(hit.transform.position, transform.position);

                int damage = Mathf.RoundToInt(maxDamage * (knockbackRadius / distance) / knockbackRadius);

                hit.GetComponentInParent<WallBreak>().TakeDamage(damage);
            }
        }
    }
}
