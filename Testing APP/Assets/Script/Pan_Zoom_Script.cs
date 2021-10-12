using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan_Zoom_Script : MonoBehaviour
{
    public static Pan_Zoom_Script Instance;

   Vector3 touchStart;
    public float zoomOutMin;
    public float zoomOutMax;
    public float m_FieldOfView;

    public GameObject VideoUI;
    public GameObject PhotoUI;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        VideoUI.SetActive(false);
        PhotoUI.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 20f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));

        if(Camera.main.fieldOfView == 50)
        {
            VideoUI.SetActive(true);
            PhotoUI.SetActive(true);
        }

        if (Camera.main.fieldOfView >= 75)
        {
            VideoUI.SetActive(false);
            PhotoUI.SetActive(false);
        }
    }

    void zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomOutMin, zoomOutMax);
    }

}
