using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool paused = false;
    public GameObject pauseMenuUi;
    public mouselook player;
    public GameObject gunHolder;
    public GameObject endGame;

    private GameObject g;

    void Start()
    {
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
        gunHolder.SetActive(true);
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
        gunHolder.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !endGame.GetComponent<endgame>().end)
        {
            if (paused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        Object.Destroy(g);
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
        gunHolder.SetActive(true);

        
    }

    private void Pause()
    {
        g = Instantiate(pauseMenuUi.gameObject, transform);
        Time.timeScale = 0f;
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        player.enabled = false;
        gunHolder.SetActive(false);
    }

}
