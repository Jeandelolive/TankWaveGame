using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnlockZone.playerNeer || OptionMenuScript.isPaused)
        {
            Cursor.visible = true;
        } else
        {
            Cursor.visible = false;
        }
    }
}
