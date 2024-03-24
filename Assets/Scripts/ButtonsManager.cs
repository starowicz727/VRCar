using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public GameObject carElement;
    public bool activated = true;
    private float doorOpenedAngle = -0.99f;
    private float doorClosedAngle = -0.707168f;
    private float doorSpeed = 20f;
    private Coroutine corOpen, corClose;
    private Quaternion startRotation;
    private void Start()
    {
        startRotation = carElement.transform.rotation;
    }
    public void DoorHandle()
    {
        if (activated)
        {
            if (corClose != null)
            {
                StopCoroutine(corClose);
            }
            corOpen = StartCoroutine(OpenDoor());
        }
        else
        {
            if (corOpen != null)
            {
                StopCoroutine(corOpen);
            }
            corClose = StartCoroutine(CloseDoor());
        }

        activated = !activated;
    }

    IEnumerator OpenDoor()
    {
        while (carElement.transform.rotation.x > doorOpenedAngle)
        {
            carElement.transform.Rotate(Vector3.left, doorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CloseDoor()
    {
        while (carElement.transform.rotation.x < doorClosedAngle)
        {
            carElement.transform.rotation = Quaternion.RotateTowards(carElement.transform.rotation, startRotation, doorSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
