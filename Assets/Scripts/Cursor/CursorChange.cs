using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour,IPointerUpHandler, IPointerDownHandler
{
    public Texture2D cursorTexture1;//Ҫ�滻�Ĺ��ͼƬ1
    public Texture2D cursorTexture2;//Ҫ�滻�Ĺ��ͼƬ2
    public Texture2D cursorTexture3;//Ҫ�滻�Ĺ��ͼƬ3

    Texture2D t1;

    private void Awake()
    {
      //  _btn1.onClick.AddListener(() => { Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto); });
    }

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
    public void OnPointerDown(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
    }
    //��UI�����̧���ִ��
    public void OnPointerUp(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto);
    }
}