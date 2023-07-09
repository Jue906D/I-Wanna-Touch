using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture1;//要替换的光标图片1
    public Texture2D cursorTexture2;//要替换的光标图片2
    public Texture2D cursorTexture3;//要替换的光标图片3

    Texture2D t1;

    

    /*//鼠标进入3D物体后执行
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
    //鼠标离开3D物体后执行
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    //鼠标进入UI后执行
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
    //鼠标离开UI后执行
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }*/
    //在UI中鼠标点击后执行

    void Awake()
    {
       // StartCoroutine(curchange());
      
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("鼠标左键按下！");
            Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            print("鼠标抬起！");
            Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
        }
    /*    else
        {
            print("df！");
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
                print("鼠标左键按下！");
                Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                print("鼠标抬起！");
                Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                print("df！");
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
    public void OnMouseDown()       //鼠标按下
    {
        Debug.Log("down");
        Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
    }
    //在UI中鼠标抬起后执行
    public void OnMouseUp()
    {
        Debug.Log("up");
        Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
    }
*/
}