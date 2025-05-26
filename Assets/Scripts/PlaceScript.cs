using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Skripts kas pārbauda vai vilktais objekts ir novietots pareizi
public class PlaceScript : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;

    public ObjectScript objectScript;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && Input.GetMouseButtonUp(0) && !Input.GetMouseButton(2))
        {
            // Pārbauda vai objekta tags sakrīt ar mērķa tags
            if (eventData.pointerDrag.tag.Equals(tag))
            {
                // Salīdzina rotāciju un izmēru
                placeZRotation = eventData.pointerDrag.GetComponent<RectTransform>().eulerAngles.z;
                carZRotation = GetComponent<RectTransform>().eulerAngles.z;
                difZRotation = Mathf.Abs(placeZRotation - carZRotation);

                placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
                carSize = GetComponent<RectTransform>().localScale;
                xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
                ySizeDif = Mathf.Abs(placeSize.y - carSize.y);

                // Ja rotācija un izmērs ir līdzīgi uzskata par pareizu novietošanu
                if ((difZRotation <= 10 || (difZRotation >= 350 && difZRotation <= 360)) &&
                    (xSizeDif <= 0.3f && ySizeDif <= 0.3f))
                {
                    objectScript.rightPlace = true;

                    // Novieto objektu precīzi vietā
                    RectTransform dragTransform = eventData.pointerDrag.GetComponent<RectTransform>();
                    RectTransform thisTransform = GetComponent<RectTransform>();

                    dragTransform.anchoredPosition = thisTransform.anchoredPosition;
                    dragTransform.localRotation = thisTransform.localRotation;
                    dragTransform.localScale = thisTransform.localScale;

                    string placedTag = eventData.pointerDrag.tag;

                    // Ja šis tags vēl nebija novietots pievieno un palielina skaitītāju
                    if (!objectScript.placedTags.Contains(placedTag))
                    {
                        objectScript.correctlyPlacedCount++;
                        objectScript.placedTags.Add(placedTag);
                    }

                    // Atskaņo atbilstošo skaņu
                    PlaySuccessSound(placedTag);

                    // Ja visi 12 objekti ir vietā parāda Pabeigšanas paneli un zvaigznes atkarībā no laika laika
                    if (objectScript.correctlyPlacedCount >= 12)
                    {
                        objectScript.completePanel.SetActive(true);

                        string[] timeParts = objectScript.timerText.text.Split(':');
                        int minutes = int.Parse(timeParts[0]);
                        int seconds = int.Parse(timeParts[1]);
                        float totalTime = minutes * 60 + seconds;

                        if (totalTime <= 60)
                        {
                            objectScript.star1.SetActive(true);
                            objectScript.star2.SetActive(true);
                            objectScript.star3.SetActive(true);
                        }
                        else if (totalTime <= 120)
                        {
                            objectScript.star1.SetActive(true);
                            objectScript.star2.SetActive(true);
                        }
                        else if (totalTime <= 180)
                        {
                            objectScript.star1.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                // Ja objekts nepareizs — atgriež sākotnējā vietā un atskaņo kļūdas skaņu
                objectScript.rightPlace = false;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);
                ResetToOriginalPosition(eventData.pointerDrag);
            }
        }
    }

    // Atgriež objektu sākotnējā pozīcijā
    private void ResetToOriginalPosition(GameObject obj)
    {
        string tag = obj.tag;
        switch (tag)
        {
            case "Garbage": obj.GetComponent<RectTransform>().localPosition = objectScript.gTruckPos; break;
            case "Medic": obj.GetComponent<RectTransform>().localPosition = objectScript.medicPos; break;
            case "School": obj.GetComponent<RectTransform>().localPosition = objectScript.sBusPos; break;
            case "Cement": obj.GetComponent<RectTransform>().localPosition = objectScript.cementTruckPos; break;
            case "b2": obj.GetComponent<RectTransform>().localPosition = objectScript.b2Pos; break;
            case "e46": obj.GetComponent<RectTransform>().localPosition = objectScript.e46Pos; break;
            case "e61": obj.GetComponent<RectTransform>().localPosition = objectScript.e61Pos; break;
            case "Exkavator": obj.GetComponent<RectTransform>().localPosition = objectScript.exkavatorPos; break;
            case "polic": obj.GetComponent<RectTransform>().localPosition = objectScript.policeCarPos; break;
            case "Traktor": obj.GetComponent<RectTransform>().localPosition = objectScript.traktorPos; break;
            case "Traktor5": obj.GetComponent<RectTransform>().localPosition = objectScript.traktor5Pos; break;
            case "Ugunsdzeseji": obj.GetComponent<RectTransform>().localPosition = objectScript.ugunsdzesējiPos; break;
        }
    }

    // Atskaņo pareizo skaņu atkarībā no objekta
    private void PlaySuccessSound(string tag)
    {
        switch (tag)
        {
            case "Garbage": objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]); break;
            case "Medic": objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]); break;
            case "School": objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]); break;
            case "Cement": objectScript.audioSource.PlayOneShot(objectScript.audioClips[5]); break;
            case "b2": objectScript.audioSource.PlayOneShot(objectScript.audioClips[6]); break;
            case "e46": objectScript.audioSource.PlayOneShot(objectScript.audioClips[7]); break;
            case "e61": objectScript.audioSource.PlayOneShot(objectScript.audioClips[8]); break;
            case "Exkavator": objectScript.audioSource.PlayOneShot(objectScript.audioClips[9]); break;
            case "polic": objectScript.audioSource.PlayOneShot(objectScript.audioClips[10]); break;
            case "Traktor": objectScript.audioSource.PlayOneShot(objectScript.audioClips[11]); break;
            case "Traktor5": objectScript.audioSource.PlayOneShot(objectScript.audioClips[12]); break;
            case "Ugunsdzeseji": objectScript.audioSource.PlayOneShot(objectScript.audioClips[13]); break;
        }
    }
}
