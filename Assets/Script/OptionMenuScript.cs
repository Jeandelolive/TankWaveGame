using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuScript : MonoBehaviour
{

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            //Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            //Cursor.visible = false;
        }
    }

    private void OnGUI()
    {
        if (isPaused)
        {
            // Si on clique sur le bouton alors isPaused devient faux donc le jeu reprend
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continue"))
            {
                isPaused = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Exit"))
            {
                Application.LoadLevel(0);
            }
        }
    }

    private bool getIsPaused()
    {
        return isPaused;
    }
}
