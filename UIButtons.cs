using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public bool exit;
    public string sceneChange;
    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonClick()
    {
        Time.timeScale = 1f;
        if (exit) Application.Quit();
        SceneManager.LoadScene("Scenes/" + sceneChange);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
