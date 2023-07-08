using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointIns : MonoBehaviour
{

    [Space]
    [Header("Stats")]
    public Vector2 aim;
    int cpflag;



    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("touch0");
        if (collision.gameObject.layer == 10)
        {
            //Debug.Log("touch");
            if (Vector2.Dot(collision.GetComponent<Movement>().fdir.normalized, aim) > 0.5)
            {

                GameObject.Find("CPpool").GetComponent<CheckPoint>().NextCP();
                Debug.Log("ok");
                Destroy(this.gameObject);

            }

        }

    }
    

    // Start is called before the first frame update
    void OnEnable()
    {
        aim = aim.normalized;

        cpflag = GameObject.Find("CPpool").GetComponent<CheckPoint>().cpflag;

        Debug.Log("new " + cpflag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
