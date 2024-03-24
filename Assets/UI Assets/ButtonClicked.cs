using HurricaneVR.Framework.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ButtonClicked : MonoBehaviour
{
    [SerializeField]
    GameObject tohide;
    [SerializeField]
    GameObject toUNhide;

    private AudioSource audioCanvas;

    private void Start()
    {
        audioCanvas = GameObject.Find("CanvasGPS").GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        IEnumerator coroutine = UIDelay(0.3f);
        StartCoroutine(coroutine);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioCanvas.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //audioCanvas.Play();
            toUNhide.SetActive(true);
            tohide.SetActive(false);
        }
    }

    IEnumerator UIDelay(float waitTime)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<BoxCollider>().enabled = true;
    }

}
