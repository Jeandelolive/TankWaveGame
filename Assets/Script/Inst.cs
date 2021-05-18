using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst : MonoBehaviour
{
    public GameObject prefab;
    private int d;
    // Start is called before the first frame update
    void Start()
    {
        d = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(d, 0, 0), Quaternion.identity);
            d = d + 10;
        }
    }
}
