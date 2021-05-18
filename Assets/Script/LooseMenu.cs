using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

        public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        Application.Quit();
    }
}
