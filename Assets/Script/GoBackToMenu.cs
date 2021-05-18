﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMenu : MonoBehaviour
{
    public GUISkin mySkin;
    public GUIStyle myStyle;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnGUI()
    {
        GUI.skin = mySkin;

        if (GUI.Button(new Rect(20, 20, 200, 100), "Menu"))
        {
            Application.LoadLevel(0);
        }
    }
}
