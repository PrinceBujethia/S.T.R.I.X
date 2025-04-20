//using UnityEngine;
//using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;

//public class URPVisualAdjuster : MonoBehaviour
//{
//    public Volume volume;

//    private ColorAdjustments colorAdjustments;
//    private WhiteBalance whiteBalance;

//    [Range(-10f, 10f)] public float brightness = 0f;
//    [Range(-100f, 100f)] public float warmth = 0f;

//    public float brightnessStep = 0.2f;
//    public float warmthStep = 5f;

//    void Start()
//    {
//        if (volume == null)
//        {
//            Debug.LogError("Volume is not assigned.");
//            return;
//        }

//        volume.profile.TryGet(out colorAdjustments);
//        volume.profile.TryGet(out whiteBalance);

//        if (colorAdjustments == null || whiteBalance == null)
//        {
//            Debug.LogError("ColorAdjustments or WhiteBalance not found in Volume.");
//        }
//    }

//    void Update()
//    {
//        if (colorAdjustments == null || whiteBalance == null) return;

//        // Brightness controls
//        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus))
//        {
//            brightness = Mathf.Clamp(brightness + brightnessStep, -10f, 10f);
//            colorAdjustments.postExposure.value = brightness;
//        }
//        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore))
//        {
//            brightness = Mathf.Clamp(brightness - brightnessStep, -10f, 10f);
//            colorAdjustments.postExposure.value = brightness;
//        }

//        // Warmth controls
//        if (Input.GetKeyDown(KeyCode.LeftBracket))
//        {
//            warmth = Mathf.Clamp(warmth - warmthStep, -100f, 100f);
//            whiteBalance.temperature.value = warmth;
//        }
//        else if (Input.GetKeyDown(KeyCode.RightBracket))
//        {
//            warmth = Mathf.Clamp(warmth + warmthStep, -100f, 100f);
//            whiteBalance.temperature.value = warmth;
//        }
//    }
//}
