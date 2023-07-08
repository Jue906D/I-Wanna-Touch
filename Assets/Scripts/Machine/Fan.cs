using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    [Space]
    [Header("Stats")]
    public Vector2 aim;
    public float power;
 //   int cpflag;



    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("touch0");
        if (collision.gameObject.layer == 10)
        {
            //Debug.Log("touch");
            //if (Vector2.Dot(collision.GetComponent<Movement>().fdir.normalized, aim) > 0.5)
            {

                collision.GetComponent<Rigidbody2D>().velocity += aim * power;  
            /*    GameObject.Find("CPpool").GetComponent<CheckPoint>().NextCP();
                Debug.Log("ok");
                Destroy(this.gameObject);*/

            }

        }

    }
}
