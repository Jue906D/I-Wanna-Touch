using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind: MonoBehaviour
{
    [SerializeField] GameObject W;
    [SerializeField] float radius;
    [SerializeField] int zh;
    public IEnumerator goWind()
    {

        Movement.isWind = true;
        W.transform.position = new Vector3(-radius * Movement.wdir.x,
                                            -radius * Movement.wdir.y,
                                            0.5f

                                            );
        //Debug.Log(Mathf.Atan2(Movement.wdir.y, Movement.wdir.x) * (180 / Mathf.PI));
        //Debug.Log(Movement.wdir);

        W.transform.Rotate(0, 0, Mathf.Atan2(Movement.wdir.y, Movement.wdir.x)* (180 / Mathf.PI), Space.Self);
        for (int i = 0; i < zh*2;++i )
        {
            W.transform.position += new Vector3(radius / zh * Movement.wdir.x,
                                            radius / zh * Movement.wdir.y,
                                             0.5f

                                            );
            
            yield return new WaitForSeconds(0.02f);
        }
        W.transform.Rotate  (0,0, -Mathf.Atan2(Movement.wdir.y, Movement.wdir.x)* (180 / Mathf.PI), Space.Self);
        Movement.isWind = false;
    }
}
