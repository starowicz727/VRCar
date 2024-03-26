using HurricaneVR.Framework.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public GameObject window;
    public bool up = true;
    private float speed = 0.2f;
    private Vector3 windowOpened;
    private Vector3 windowClosed;

    private void Start()
    {
        windowClosed = window.transform.position;
        windowOpened = new Vector3(window.transform.position.x, window.transform.position.y - 0.6f, window.transform.position.z );
    }
    void Update()
    {
        if(this.gameObject.GetComponent<HVRPhysicsButton>().IsPressed)
        {
            if (up)
            {
                WindowUp();
            }
            else
            {
                WindowDown();
            }
        }
    }

    public void WindowDown()
    {
        if(window.transform.position.y > windowOpened.y)
        {
            window.transform.position = Vector3.MoveTowards(window.transform.position, windowOpened, speed * Time.deltaTime);
        }
    }
    public void WindowUp()
    {
        if (window.transform.position.y < windowClosed.y)
        {
            window.transform.position = Vector3.MoveTowards(window.transform.position, windowClosed, speed * Time.deltaTime);
        }
    }
    
}
