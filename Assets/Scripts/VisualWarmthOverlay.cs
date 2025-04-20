using UnityEngine;
using UnityEngine.UI;

public class VisualWarmthOverlay : MonoBehaviour
{
    public Image warmTintImage;
    private float warmthLevel = 0f; // Range: 0 (off) to 1 (full warm)

    void Update()
    {
        // Increase warmth with ]
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            warmthLevel = Mathf.Clamp01(warmthLevel + 0.1f);
            UpdateOverlay();
        }

        // Decrease warmth with [
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            warmthLevel = Mathf.Clamp01(warmthLevel - 0.1f);
            UpdateOverlay();
        }
    }

    void UpdateOverlay()
    {
        Color color = new Color(1f, 0.6f, 0.3f, warmthLevel * 0.4f); // Orange tint
        warmTintImage.color = color;
    }
}
