using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInsideCar : MonoBehaviour
{
    [SerializeField]
    GameObject doorTrigger1;
    [SerializeField]
    GameObject doorTrigger2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Wait2s");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorTrigger1.SetActive(true);
            doorTrigger2.SetActive(true);
        }
    }

    IEnumerator Wait2s()
    {
        yield return new WaitForSeconds(2);
        doorTrigger1.SetActive(false);
        doorTrigger2.SetActive(false);
    }
}
