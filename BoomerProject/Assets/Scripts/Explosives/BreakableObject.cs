using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [Header("Variables")]
    public int health = 50;
    public int destroyedMoneyGain;

    [Header("Objects")]
    public GameObject[] destroyedPrefabs;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        //this spawns the broken object
        GameObject destroyed = Instantiate(destroyedPrefabs[Random.Range(0,destroyedPrefabs.Length)], transform.position, transform.rotation);
        destroyed.transform.parent = FindObjectOfType<PhysicsObjectHandler>().transform;

        //this gives the money for the broken thing
        if (FindObjectOfType<Money>())
        {
            FindObjectOfType<Money>().GainMoney(destroyedMoneyGain);
        }

        //this destroys the original object
        Destroy(gameObject);
    }
}
