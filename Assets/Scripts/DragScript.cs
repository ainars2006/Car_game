using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
    
public class DragScript : MonoBehaviour, IDragHandler, IBeginDragHandler,
    IEndDragHandler  {
    private RectTransform rectTransform;
    public Canvas canva;
    private CanvasGroup canvasGroup;
    public ObjectScript objectScript;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void onPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(2) == false)
        {

            objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]);

        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            objectScript.lastDragged = null;
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
            rectTransform.SetSiblingIndex(50);

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition =
            new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition.x = Mathf.Clamp(
            mousePosition.x, 0 + rectTransform.rect.width / 2,
            Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(
           mousePosition.y, 0 + rectTransform.rect.height / 2,
           Screen.height - rectTransform.rect.height / 2);

        transform.position = mousePosition;
    }
        public void OnEndDrag(PointerEventData eventData) {
        if(Input.GetMouseButtonUp(0)) 
            {

                objectScript.lastDragged = eventData.pointerDrag;
                canvasGroup.alpha = 1f;

            if (objectScript.rightPlace == false)
            {
                canvasGroup.blocksRaycasts = true;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]);

            }
            else
            {
                objectScript.lastDragged = null;
            }
            objectScript.rightPlace = false;
        }
     }
 }
