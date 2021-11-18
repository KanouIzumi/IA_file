using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Reset_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject resetGameObject;
    bool position = false;
    public Vector3 StartPosition;
    public Quaternion StartRotation;
    public Vector3 StartScale;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (position == false)
            return;

        resetGameObject.transform.position = StartPosition;
        resetGameObject.transform.rotation = StartRotation;
        resetGameObject.transform.localScale = StartScale;

    }


    public void OnPointerDown(PointerEventData pointerEventData)
    {
        position = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        position = false;
    }

}
