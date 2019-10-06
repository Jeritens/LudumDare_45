using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoverEvent : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public UnityEvent OnHoverStart;
    public UnityEvent OnHoverExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHoverStart.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHoverExit.Invoke();
    }
}
