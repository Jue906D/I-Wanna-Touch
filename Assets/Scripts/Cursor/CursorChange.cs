using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture1;//Ҫ�滻�Ĺ��ͼƬ1
    public Texture2D cursorTexture2;//Ҫ�滻�Ĺ��ͼƬ2
    public Texture2D cursorTexture3;//Ҫ�滻�Ĺ��ͼƬ3

    Texture2D t1;

    

    /*//������3D�����ִ��
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
    //����뿪3D�����ִ��
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    //������UI��ִ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
    //����뿪UI��ִ��
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }*/
    //��UI���������ִ��

    void Awake()
    {
       // StartCoroutine(curchange());
      
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("���������£�");
            Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            print("���̧��");
            Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
        }
    /*    else
        {
            print("df��");
            Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
        }
        //yield return new WaitForSeconds(0.5f);*/
    }

    public IEnumerator curchange()
    {
        for(; ; )
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("���������£�");
                Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                print("���̧��");
                Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                print("df��");
                Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

  /*  void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
        }
        else //if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
        }

    }*/
/*
    public void OnMouseDown()       //��갴��
    {
        Debug.Log("down");
        Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
    }
    //��UI�����̧���ִ��
    public void OnMouseUp()
    {
        Debug.Log("up");
        Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
    }
*/
}