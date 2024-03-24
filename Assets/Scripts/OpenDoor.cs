using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    int check = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&check==0)
        {
            anim.SetBool("Open", true);
            check = 1;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player"&&check==1)
        {
            anim.SetBool("Open",false);
            check = 0;
        }
    }
}
