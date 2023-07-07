using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShake : MonoBehaviour
{
    [SerializeField] FlyData flyData;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < 0)
        {
            float ram = Random.Range(0f, flyData.shakeRange);
            Debug.Log(ram);
            rb.velocity += new Vector2(rb.velocity.x > 0 ? -ram : ram, 0);
        }
    }
}
