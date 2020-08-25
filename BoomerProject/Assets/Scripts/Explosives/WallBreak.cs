using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    public int health;
    public int moneyGain;
    public GameObject[] shatteredWall;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        GameObject wall = Instantiate(shatteredWall[Random.Range(0,shatteredWall.Length)],transform.position,transform.rotation);

        wall.transform.localScale = transform.localScale;
        wall.transform.parent = GameObject.FindObjectOfType<PhysicsObjectHandler>().transform;

        if (FindObjectOfType<Money>())
        {
            FindObjectOfType<Money>().GainMoney(moneyGain);
        }

        Destroy(gameObject);
    }
}
