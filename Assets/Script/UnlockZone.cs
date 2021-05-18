using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockZone : MonoBehaviour
{
    public static bool playerNeer;
    public GameObject Wall;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerNeer = false;
        player = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        
        if (dist < 8.0 && player.GetComponent<MovePov>().getPlayerPoints() >= 200 && Input.GetKey(KeyCode.U))
        {
            player.GetComponent<MovePov>().usePlayerPoint(200);
            Wall.SetActive(false);
        }
    }
}
