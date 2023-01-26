using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoHide : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool autoHide;
    public float hideDelay = 5f;
    public CanvasGroup canvsGrp;
    public Camera cam;
    float timeWasted = 0;

    private RectTransform rctTrnsfrm;

    public bool m_isHolding = false;
    void Start()
    {
        rctTrnsfrm = GetComponent<RectTransform>();
    }

    

    void Update()
    {
        timeWasted += Time.deltaTime;
        if (timeWasted > 3 && !m_isHolding && autoHide)
        {
            HidePanel();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 localpoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (rctTrnsfrm, eventData.position, cam, out localpoint))
        {
            m_isHolding = true;
            ShowPanel();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Vector2 localpoint; 
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (rctTrnsfrm, eventData.position, cam, out localpoint))
        {
            m_isHolding = false;
            timeWasted = 0;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 localpoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (rctTrnsfrm, eventData.position, cam, out localpoint))
        {
            m_isHolding = true;
            ShowPanel();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 localpoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (rctTrnsfrm, eventData.position, cam, out localpoint))
        {
            m_isHolding = false;
            timeWasted = 0;
        }

    }

    public void ShowPanel()
    {
        canvsGrp.alpha = 1;
        timeWasted = 0;
        // canvsGrp.interactable = true;
    }
    public void HidePanel()
    {
        canvsGrp.alpha = 0;
        // canvsGrp.interactable = false;
    }

}


