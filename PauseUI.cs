using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private pauseMenu pauseMenu;
    private void Start()
    {
        pauseMenu = FindObjectOfType<pauseMenu>();
    }
    // Start is called before the first frame update
    public void ResumeCONFIGURE()
    {
        pauseMenu.Resume();
    }
}
