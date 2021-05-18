using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movmentCylinder : MonoBehaviour
{
    public GameObject prefab;
    private bool InstDone = false;
    private Vector3 direction = new Vector3(1, 0, 0);
    private Vector3 angle = new Vector3(1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.Rotate(angle, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == "obj1" || collision.gameObject.name == "obj2") && InstDone == false)
        {
            Instantiate(prefab, collision.gameObject.transform.position, Quaternion.identity);
            this.InstDone = true;
            Destroy(collision.gameObject);
        }
    }
}
