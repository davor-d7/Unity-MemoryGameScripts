using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour
{
    public GameObject vrijeme;
    public GameObject timer;
    public GameObject uiHolder;
    public Button button;
    public AudioSource glazbica;
    public GameObject startMenu;
    public GameObject endMenu;
    public GameObject clickCunt;
    public GameObject clickText;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && startMenu.activeSelf == false && endMenu.activeSelf == false)
        {
            if (uiHolder.activeSelf == true)
            {
                uiHolder.SetActive(false);
                glazbica.UnPause();
                timer.GetComponent<TimeCount>().enabled = true;

            }
            else if (uiHolder.activeSelf == false)
            {
                uiHolder.SetActive(true);
                glazbica.Pause();
                timer.GetComponent<TimeCount>().enabled = false;

            }

        }
    }
    public void ShowVrijeme()
    {
        vrijeme.SetActive(true);
        timer.SetActive(true);
        clickCunt.SetActive(true);
        clickText.SetActive(true);
        button.enabled = false;
    }

    public void Resume()
    {
        uiHolder.SetActive(false);
        glazbica.UnPause();
        timer.GetComponent<TimeCount>().enabled = true;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
