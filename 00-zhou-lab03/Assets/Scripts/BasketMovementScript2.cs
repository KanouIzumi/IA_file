using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript2 : MonoBehaviour
{
    public float speed;

    public float score;
    public Text ScoreText;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

      transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, 0);
     

        ScoreText.text = "Score:" + score;

        
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Healthy")
        {
            score += 10;
            Destroy(collision.gameObject);

            if (score >= 100)
                SceneManager.LoadScene("GameWin");
        }
        else if (collision.gameObject.tag == "Unhealthy")
        {
            SceneManager.LoadScene("GameLose");
        }
    }

}
