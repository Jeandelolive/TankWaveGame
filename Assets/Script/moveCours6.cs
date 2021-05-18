using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCours6 : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    public LayerMask ground;
    public Transform feet;
    private Vector3 direction;
    private Rigidbody rBody;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        jumpHeight = 5.0f;
        rBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            //rBody.AddForce(direction * 0.5f, ForceMode.VelocityChange);
            rBody.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }

        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audio.Play();
            rBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
    }
}
