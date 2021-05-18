using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject1 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }
    }
}
