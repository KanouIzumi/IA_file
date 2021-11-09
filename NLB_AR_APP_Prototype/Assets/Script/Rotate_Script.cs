using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate_Script : MonoBehaviour
{
    public float rotationRate = 3.0f;
    private float m_previousX;
    private float m_previousY;
    private LayerMask targetLayer;

    //to keep track if we are dragging or not
    public bool isDragging;

    //to keep track if is it rotating
    public bool isRotating;

    //the model that we want it to drag
    public GameObject AnimalModel;

    public Animator cubeAnim;

    // Start is called before the first frame update
    void Start()
    {
        AnimalModel = this.gameObject.GetComponent<GameObject>();
        cubeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //this is for moble control
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 1000, targetLayer))
            {
                isRotating = true;
                m_previousX = Input.GetTouch(0).position.x;
                m_previousY = Input.GetTouch(0).position.y;
            }


        }

        // get the user touch input
        if (Input.GetMouseButton(0))
        {
            var touch = Input.mousePosition;
            var deltaX = -(Input.mousePosition.y - m_previousY) * rotationRate;
            var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
            transform.Rotate(deltaX, deltaY, 0, Space.World);

            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }

    }

}
