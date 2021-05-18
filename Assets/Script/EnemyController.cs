using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public GameObject explosion;
    private float speed;
    private WaveMan waveManScript;
    private float health;
    private float maxHealth;
    private Text healthText;
    GameObject player;
    public GameObject bulletPrefab;
    public GameObject speedBoost;
    public Transform bulletSpawn;
    private float timeDelay;
    private float time;
    private UnityEvent dieEvent;
    public int dropChance;
    private float shootDist;
    private AudioSource explosionSound;
    private AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        player = GameObject.Find("Tank");
        target = player.transform;

        if (gameObject.tag == "Boss")
        {
            health = 200;
            shootDist = 50;
        } else
        {
            health = 10;
            shootDist = 10;
        }
        
        maxHealth = 100;
        time = Time.time;
        dropChance = 5;
        //healthText = transform.Find("Canvas").Find("Text").GetComponent<Text>();

        dieEvent = new UnityEvent();
        GameObject light = GameObject.Find("Light");
        dieEvent.AddListener(light.GetComponent<WaveMan>().enemyDie);
        fireSound = GetComponent<AudioSource>();
        explosionSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay = Time.time - time;
        transform.LookAt(target);
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < shootDist && timeDelay > 2)
        {
            fireFunction();
            time = Time.time;
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        //healthText.text = health.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                explosionSound.Play();
                Destroy(this);
                Destroy(gameObject);
                dieEvent.Invoke();
                dropBonnus();
            }
        }
    }

    void fireFunction()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        fireSound.Play();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 19;
        Destroy(bullet, 2.0f);
    }

    private void dropBonnus()
    {
        int drop = Random.Range(1, dropChance);

        if (drop == 1)
        {
            Vector3 tmp = transform.position;
            tmp.y = 1;
            Instantiate(speedBoost, tmp, transform.rotation);
        }
    }
}
