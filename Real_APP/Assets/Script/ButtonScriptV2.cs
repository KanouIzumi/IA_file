using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScriptV2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoTo360View()
    {
        SceneManager.LoadScene("View360PIC");
    }

    public void GoToCorridor()
    {
        SceneManager.LoadScene("Hallway");
    }

    public void GoTo360Video()
    {
        SceneManager.LoadScene("View360Video");
    }

    public void Back()
    {
        SceneManager.LoadScene("ARscene");
    }
}
