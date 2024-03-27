using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMaterial : MonoBehaviour
{
    [SerializeField]
    List<GameObject> carElements;

    private AudioSource audioCanvas;

    private void Start()
    {
        audioCanvas = GameObject.Find("CanvasConfiguration").GetComponent<AudioSource>();
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
            foreach (GameObject obj in carElements)
            {
                obj.GetComponent<MeshRenderer>().material = this.GetComponent<Image>().material;
            }
        }
    }

    IEnumerator UIDelay(float waitTime)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
