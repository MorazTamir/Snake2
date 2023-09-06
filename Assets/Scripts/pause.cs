using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause: MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

}