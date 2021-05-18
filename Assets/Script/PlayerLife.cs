using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public int nbLife;
    public List<GameObject> lifeList;

    private float timer;
    private float timerMax;

    // Start is called before the first frame update
    void Start()
    {
        nbLife = 2;
        lifeList.Add(GameObject.Find("LifePoint1"));
        lifeList.Add(GameObject.Find("LifePoint2"));
        lifeList.Add(GameObject.Find("LifePoint3"));
        timerMax = 1;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (nbLife < 0)
        {
            Application.LoadLevel(2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && nbLife >= 0)
        {
            Destroy(lifeList[nbLife]);
            nbLife -= 1;
        }
    }

    private bool waitFunction()
    {
        timer += Time.deltaTime;

        if (timer >= timerMax)
            return true;
        return false;
    }
}
