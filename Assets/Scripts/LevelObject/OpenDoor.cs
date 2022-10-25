using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Door;
    public Animator DoorAnimation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue")
        {
            DoorAnimation.SetTrigger("Destroy");
            Destroy(Door, 10);
            Destroy(gameObject, 10);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Blue")
        {
            DoorAnimation.SetTrigger("Destroy");
            Destroy(Door, 10);
            Destroy(gameObject, 10);
        }
    }
}
