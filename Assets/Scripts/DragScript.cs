using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Skripts, kas ļauj objektam tikt vilktam ar peli
public class DragScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform; // UI objekta transformācija
    public Canvas canva; // Atsauce uz kanvu
    private CanvasGroup canvasGroup; // Kontrolē objekta redzamību un mijiedarbību
    public ObjectScript objectScript; // Atsauce uz citu skriptu ar objektu datiem

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Izsauc skaņu, kad objekts tiek nospiests
    public void onPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(2) == false)
        {
            objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]);
        }
    }

    // Sākot vilkšanu
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            objectScript.lastDragged = null;
            canvasGroup.alpha = 0.6f; // Padara objektu daļēji caurspīdīgu
            canvasGroup.blocksRaycasts = false; // Ļauj citiem objektiem saņemt klikšķus
            rectTransform.SetSiblingIndex(50); // Novieto objektu virspusē
        }
    }

    // Vilkšanas laikā
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Ierobežo vilkšanu ekrāna robežās
        mousePosition.x = Mathf.Clamp(
            mousePosition.x, 0 + rectTransform.rect.width / 2,
            Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(
           mousePosition.y, 0 + rectTransform.rect.height / 2,
           Screen.height - rectTransform.rect.height / 2);

        transform.position = mousePosition;
    }

    // Beidzot vilkšanu
    public void OnEndDrag(PointerEventData eventData)
    {
        if(Input.GetMouseButtonUp(0))
        {
            objectScript.lastDragged = eventData.pointerDrag;
            canvasGroup.alpha = 1f; // Atgriež pilnu redzamību

            if (!objectScript.rightPlace)
            {
                canvasGroup.blocksRaycasts = true;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]); // Atskaņo kļūdas skaņu
            }
            else
            {
                objectScript.lastDragged = null;
            }

            objectScript.rightPlace = false;
        }
    }
}
