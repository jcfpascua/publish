using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleController : MonoBehaviour
{
    public bool isPlayer = false;  
    public float scaleStep = 0.1f; 
    public float minScale = 0.1f;
    public float maxScale = 3f;

    void Update()
    {
        Vector3 newScale = transform.localScale;

        if (Keyboard.current.eKey.wasPressedThisFrame)
            newScale -= Vector3.one * scaleStep;
        if (Keyboard.current.rKey.wasPressedThisFrame)
            newScale += Vector3.one * scaleStep;

        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        transform.localScale = newScale;
    }
}
