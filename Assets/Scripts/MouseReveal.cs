using UnityEngine;
using UnityEngine.UI;

// Atjaunina materiāla parametru atbilstoši peles pozīcijai
public class MouseReveal : MonoBehaviour
{
    [SerializeField] private Material revealMaterial; // Materiāls kam tiek padota peles pozīcija

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        // Konvertē peles pozīciju
        Vector2 uv = new Vector2(mousePos.x / Screen.width, mousePos.y / Screen.height);

        // Nosūta UV koordinātas materiālam
        revealMaterial.SetVector("_Mouse", uv);
    }
}
