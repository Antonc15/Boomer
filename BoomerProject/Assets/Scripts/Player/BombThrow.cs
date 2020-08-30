using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrow : MonoBehaviour
{

    public GameObject mine;
    public float throwForce;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw ();
        }
    }

    void Throw()
    {
        GameObject mineClone = Instantiate(mine, transform.position, Quaternion.LookRotation(transform.forward));
        mineClone.GetComponent<Rigidbody>().velocity = new Vector3(0,GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity.y,0);
        mineClone.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }
}
