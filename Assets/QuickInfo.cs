using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Info;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Info.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Info.SetActive(false);
    }
}
