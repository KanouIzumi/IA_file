using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ObjectMovement : MonoBehaviour
{
    private float ySpeed = -4f;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        // Check if the name of the current Active Scene is your first Scene.
        if (scene.name == "GamePlay_Level 2")
        {
            ySpeed = -10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, ySpeed * Time.deltaTime, 0f));
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
