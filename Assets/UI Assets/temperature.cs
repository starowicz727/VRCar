using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class temperature : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tempTxt;
    [SerializeField]
    bool isUp;

    float temp = 20f;

    private void OnEnable()
    {
        IEnumerator coroutine = UIDelay(0.3f);
        StartCoroutine(coroutine);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            temp = float.Parse(tempTxt.text);
            if (isUp && temp <28f)
            {
                temp += 0.5f;
                tempTxt.SetText(temp.ToString("F1"));
                IEnumerator coroutine = UIDelay(0.3f);
                StartCoroutine(coroutine);
            }
            if(!isUp && temp> 18f)
            {
                temp -= 0.5f;
                tempTxt.SetText(temp.ToString("F1"));
                IEnumerator coroutine = UIDelay(0.3f);
                StartCoroutine(coroutine);
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
