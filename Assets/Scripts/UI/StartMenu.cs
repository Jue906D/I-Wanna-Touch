using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    //[SerializeField] GameObject StartButton;
    [SerializeField] GameObject StartUI;

    public void StartmyGame()
    {
        Debug.Log("ok");
        StartUI.SetActive(false);
        
        Time.timeScale = 1f;
    }

    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        //Time.timeScale = 0f;
    }

}
