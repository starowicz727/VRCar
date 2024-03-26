using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public GameObject carElement;
    public bool activated = true;

    private Coroutine corOpen, corClose;

    private Quaternion startRotation;
    private float doorOpenedAngle = -0.99f;              
    private float doorSpeed = 25f;                      
    private float trunkOpenedAngle = -0.2f;
    private float trunkSpeed = -25f;
    private float roofSpeed = 0.05f;
    private Vector3 roofOpened = new Vector3 (0.4235585f, 0.03f, 0.3714397f);
    private Vector3 roofClosed = new Vector3 (0.4235585f, 0.372f, 0.3714397f);


    //testing : 
    //public bool useOnce = false;
    //private void Update()
    //{
    //    if (useOnce) { RoofHandle(); useOnce = false; Debug.Log(carElement.transform.rotation.x); }
    //}

    private void Start()
    {
        startRotation = carElement.transform.rotation;
    }
    
    public void TrunkHandle()
    {
        if (activated)
        {
            if (corClose != null)
            {
                StopCoroutine(corClose);
            }
            corOpen = StartCoroutine(OpenTrunk());
        }
        else
        {
            if (corOpen != null)
            {
                StopCoroutine(corOpen);
            }
            corClose = StartCoroutine(CloseTrunk());
        }

        activated = !activated;
    }

    IEnumerator OpenTrunk()
    {
        while (carElement.transform.rotation.x < trunkOpenedAngle)
        {
            carElement.transform.Rotate(Vector3.left, trunkSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CloseTrunk()
    {
        while (carElement.transform.rotation.x > startRotation.x) //doorClosedAngle
        {
            carElement.transform.rotation = Quaternion.RotateTowards(carElement.transform.rotation, startRotation, doorSpeed * Time.deltaTime);
            yield return null;
        }
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
        while (carElement.transform.rotation.x < startRotation.x) //doorClosedAngle
        {
            carElement.transform.rotation = Quaternion.RotateTowards(carElement.transform.rotation, startRotation, doorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void RoofHandle()
    {
        if (activated)
        {
            if (corClose != null)
            {
                StopCoroutine(corClose);
            }
            corOpen = StartCoroutine(OpenRoof());
        }
        else
        {
            if (corOpen != null)
            {
                StopCoroutine(corOpen);
            }
            corClose = StartCoroutine(CloseRoof());
        }

        activated = !activated;
    }
    IEnumerator OpenRoof()
    {
        while (carElement.transform.localScale.y > roofOpened.y)
        {
            carElement.transform.localScale = Vector3.MoveTowards(carElement.transform.localScale, roofOpened, roofSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CloseRoof() 
    {
        while (carElement.transform.localScale.y < roofClosed.y)
        {
            carElement.transform.localScale = Vector3.MoveTowards(carElement.transform.localScale, roofClosed, roofSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
