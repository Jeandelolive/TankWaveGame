using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveMan : MonoBehaviour
{

    public GameObject enemy;
    public GameObject Boss;
    public int nbEnemyLeft;
    private int nbWave;
    public int startNbEnemy;
    private UnityEvent givePoint;
    private UnityEvent healPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startNbEnemy = 5;
        nbWave = 1;
        instantiateEnemy();
        Cursor.visible = false;

        givePoint = new UnityEvent();
        healPlayer = new UnityEvent();
        GameObject player = GameObject.Find("Tank");
        givePoint.AddListener(player.GetComponent<MovePov>().playerEarnPoint);
        healPlayer.AddListener(player.GetComponent<MovePov>().healPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (nbEnemyLeft == 0)
        {
            nbWave++;
            startNbEnemy = startNbEnemy + nbWave + 1;
            instantiateEnemy();
            if (nbWave > 1 )
            {
                healPlayer.Invoke();
            }
        }
    }

    private void instantiateEnemy()
    {
        if ((nbWave % 5) == 0)
        {
            nbEnemyLeft = 1;
            Instantiate(Boss, new Vector3(11, 0, 4), transform.rotation);
            return;
        }
        for (int i = 0; i < startNbEnemy; i++)
        {
            Instantiate(enemy, getRandomPosition(), transform.rotation);
        }
        nbEnemyLeft = startNbEnemy;
    }

    public void enemyDie()
    {
        nbEnemyLeft -= 1;
        givePoint.Invoke();
    }

    private Vector3 getRandomPosition()
    {
        int[] arrRange = getSpawnZone();

        float x = Random.Range(arrRange[0], arrRange[1]);
        float y = 5;
        float z = Random.Range(arrRange[2], arrRange[3]);
        Vector3 pos = new Vector3(x, y, z);

        return pos;
    }

    private int[] getSpawnZone()
    {
        GameObject player = GameObject.Find("Tank");
        Vector3 playerPos = player.transform.position;

        //zone1
        if (playerPos.x >= -50 && playerPos.x < 50 && playerPos.z >= -50 && playerPos.z < 50)
        {
            return new int[] { -30, 30, -30, 30 };
        }
        //zone2
        if (playerPos.x >= 50 && playerPos.x < 150 && playerPos.z >= -50 && playerPos.z < 50)
        {
            return new int[] { 70, 130, -30, 30 };
        }
        //zone3
        if (playerPos.x >= 150 && playerPos.x < 250 && playerPos.z >= -50 && playerPos.z < 50)
        {
            return new int[] { 130, 230, -30, 30 };
        }

        //zone4
        if (playerPos.x >= -50 && playerPos.x < 50 && playerPos.z >= 50 && playerPos.z < 150)
        {
            return new int[] { -30, 30, 70, 130 };
        }
        //zone5
        if (playerPos.x >= 50 && playerPos.x < 150 && playerPos.z >= 50 && playerPos.z < 150)
        {
            return new int[] { 70, 130, 70, 130 };
        }
        //zone6
        if (playerPos.x >= 150 && playerPos.x < 250 && playerPos.z >= 50 && playerPos.z < 150)
        {
            return new int[] { 130, 230, 70, 130 };
        }

        //zone7
        if (playerPos.x >= -50 && playerPos.x < 50 && playerPos.z >= 150 && playerPos.z < 250)
        {
            return new int[] { -30, 30, 130, 230 };
        }
        //zone8
        if (playerPos.x >= 50 && playerPos.x < 150 && playerPos.z >= 150 && playerPos.z < 250)
        {
            return new int[] { 70, 130, 130, 230 };
        }
        //zone9
        if (playerPos.x >= 150 && playerPos.x < 250 && playerPos.z >= 150 && playerPos.z < 250)
        {
            return new int[] { 130, 230, 130, 230 };
        }

        return new int[] { -30, 30, -30, 30 };
    }
}
