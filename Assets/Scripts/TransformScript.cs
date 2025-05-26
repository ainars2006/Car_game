using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skripts kas ļauj rotēt un mainīt izmēru pēdējam vilktajam objektam
public class TransformScript : MonoBehaviour
{
    public ObjectScript objectScript;

    void Update()
    {
        // Ja kāds objekts pašlaik tiek vilkts
        if (objectScript.lastDragged != null)
        {
            // Rotē pa kreisi
            if (Input.GetKey(KeyCode.Z))
            {
                objectScript.lastDragged.GetComponent<RectTransform>()
                    .transform.Rotate(0, 0, Time.deltaTime * 12f);
            }

            // Rotē pa labi
            if (Input.GetKey(KeyCode.X))
            {
                objectScript.lastDragged.GetComponent<RectTransform>()
                    .transform.Rotate(0, 0, -Time.deltaTime * 12f);
            }

            // Palielina augstumu
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector2(
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x,
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y + 0.001f
                        );
                }
            }

            // Samazina augstumu
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y > 0.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector2(
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x,
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y - 0.001f
                        );
                }
            }

            // Samazina platumu
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x > 0.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector2(
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x - 0.001f,
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y
                        );
                }
            }

            // Palielina platumu
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector2(
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x + 0.001f,
                            objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y
                        );
                }
            }
        }
    }
}
