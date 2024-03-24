using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public GameObject carElement;
    private bool activated = true;
    private float doorOpenAngle = -170f;
    private float doorCloseAngle = -90f;
    private float doorSpeed = 10f; 

    public void DoorHandle()
    {
        if (!activated)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            StartCoroutine(CloseDoor());
        }

        activated = !activated;
    }

    IEnumerator OpenDoor()
    {
        while (carElement.transform.eulerAngles.x < doorOpenAngle)
        {
            carElement.transform.Rotate(Vector3.right, doorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CloseDoor()
    {
        while (carElement.transform.eulerAngles.x > doorCloseAngle)
        {
            carElement.transform.Rotate(Vector3.right, -doorSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
