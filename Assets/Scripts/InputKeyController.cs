using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputKeyController : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public enum Keys
    {
        Left,
        Up,
        Down,
        Right
    }
    public Keys key;
    public bool isPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
