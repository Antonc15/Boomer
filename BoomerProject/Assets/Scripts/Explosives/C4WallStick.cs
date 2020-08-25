using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4WallStick : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer != LayerMask.NameToLayer("Bomb") && col.gameObject.layer != LayerMask.NameToLayer("Non-Stick"))
        {
            if (!col.transform.GetComponent<Rigidbody>() || col.transform.GetComponent<Rigidbody>() && col.transform.GetComponent<Rigidbody>().isKinematic)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.layer != LayerMask.NameToLayer("Bomb") && col.gameObject.layer != LayerMask.NameToLayer("Non-Stick"))
        {
            if (!col.transform.GetComponent<Rigidbody>() || col.transform.GetComponent<Rigidbody>() && col.transform.GetComponent<Rigidbody>().isKinematic)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
