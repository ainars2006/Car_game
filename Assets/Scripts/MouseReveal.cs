using UnityEngine;
using UnityEngine.UI;

public class MouseReveal : MonoBehaviour
{
    [SerializeField] private Material revealMaterial;

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 uv = new Vector2(mousePos.x / Screen.width, mousePos.y / Screen.height);
        revealMaterial.SetVector("_Mouse", uv);
    }
}
