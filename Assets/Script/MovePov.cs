using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePov : MonoBehaviour
{

    public float speed;
    public Transform feet;
    public LayerMask ground;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private Vector3 direction;
    private Rigidbody rbody;
    private float rotationSpeed;
    private float rotationX;
    private float rotationY;
    private AudioSource fireSound;
    private int playerHeath;
    private int playerPoint;
    private Text healthText;
    private Text pointText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        rotationSpeed = 2f;
        rotationX = 0;
        rotationY = 10f;
        rbody = GetComponent<Rigidbody>();
        fireSound = GetComponent<AudioSource>();
        playerHeath = 100;
        playerPoint = 0;
        healthText = transform.Find("Canvas").Find("PlayerHealth").GetComponent<Text>();
        pointText = transform.Find("Canvas").Find("PlayerPoint").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;

        if (direction.x != 0)
        {
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        }

        if (direction.z != 0)
        {
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);
        }
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);  

        if (Input.GetButtonUp("Fire1"))
        {
            fireFunction();

        }

        string tmp = "Health : " + playerHeath.ToString();
        healthText.text = tmp;
        tmp = "Points : " + playerPoint.ToString();
        pointText.text = tmp;

        if (playerHeath <= 0)
        {
            Application.LoadLevel(2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            playerHeath = playerHeath - 10;
        }

        if (collision.gameObject.tag == "Speed")
        {
            print("speed");

            Destroy(collision.gameObject);
            speed += 1;
        }
    }

    void fireFunction()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        fireSound.Play();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 19;
        Destroy(bullet, 2.0f);
    }

    public void playerEarnPoint()
    {
        playerPoint += 100;
    }

    public void healPlayer()
    {
        playerHeath = 100;
    }

    public int getPlayerPoints()
    {
        return playerPoint;
    }

    public void usePlayerPoint(int nbPoint)
    {
        playerPoint = playerPoint - nbPoint;
    }
}
