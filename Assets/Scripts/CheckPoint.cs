using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Space]
    [Header("Stats")]
    public Vector3 randomPosition;
    public int cpflag;


    GameObject carrot;
    int curcp;
    
    public void NextCP()
    {
        curcp++;
        Debug.Log(curcp);
       //do
        //{
            Vector3 randomPosition = new Vector3(Random.Range(-areaWidth / 2, areaWidth / 2),
                                                 Random.Range(-areaLength / 2, areaLength / 2),
                                                 0.5f);
        //} while (IsOverlapping(randomPosition));
        carrot = Instantiate(prefab, randomPosition, Quaternion.identity);
        objectPositions.Add(randomPosition);
    }

   /* public IEnumerator waitit()
    {
        yield return new WaitForSeconds(0.5f);
        NextCP();
    }*/

    public GameObject prefab;
    public float areaWidth;
    public float areaLength;
    public int objectCount;

    public List<Vector3> objectPositions;

    void Awake()
    {
       
    }

    void Start()
    {
        curcp = 0;
        cpflag = 0;
        GenerateObjects();
    }

    void GenerateObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-areaWidth / 2, areaWidth / 2),
                                                 Random.Range(-areaLength / 2, areaLength / 2),
                                                 0.5f);
        //    while (IsOverlapping(randomPosition))
            {
                randomPosition = new Vector3(Random.Range(-areaWidth / 2, areaWidth / 2),
                                                 Random.Range(-areaLength / 2, areaLength / 2),
                                                 0.5f);
            }
            cpflag++;
            carrot =Instantiate(prefab, randomPosition, Quaternion.identity);
            objectPositions.Add(randomPosition);
        }
    }

    bool IsOverlapping(Vector3 position)
    {
        for (int i = 0; i < objectPositions.Count; i++)
        {
            if (Vector3.Distance(position, objectPositions[i]) < 1.0f)
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
