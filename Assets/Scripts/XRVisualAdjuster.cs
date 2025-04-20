//using UnityEngine;
//using UnityEngine.Rendering;
//using UnityEngine.Rendering.PostProcessing;

//public class XRVisualAdjuster : MonoBehaviour
//{
//    public PostProcessVolume postProcessVolume;

//    private ColorGrading colorGrading;

//    [Header("Brightness Settings")]
//    [Range(-100f, 100f)] public float brightness = 0f;
//    public float brightnessStep = 5f;

//    [Header("Warmth Settings")]
//    [Range(-100f, 100f)] public float warmth = 0f;
//    public float warmthStep = 5f;

//    void Start()
//    {
//        if (postProcessVolume == null)
//        {
//            Debug.LogError("PostProcessVolume not assigned.");
//            return;
//        }

//        postProcessVolume.profile.TryGetSettings(out colorGrading);

//        if (colorGrading == null)
//        {
//            Debug.LogError("Color Grading is not added to the Post Process Profile.");
//        }
//    }

//    void Update()
//    {
//        if (colorGrading == null) return;

//        // Brightness control: '+' and '-'
//        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus))
//        {
//            brightness = Mathf.Clamp(brightness + brightnessStep, -100f, 100f);
//            colorGrading.postExposure.value = brightness / 20f; // scale to Unity exposure
//        }
//        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore))
//        {
//            brightness = Mathf.Clamp(brightness - brightnessStep, -100f, 100f);
//            colorGrading.postExposure.value = brightness / 20f;
//        }

//        // Warmth control: '[' and ']'
//        if (Input.GetKeyDown(KeyCode.LeftBracket))
//        {
//            warmth = Mathf.Clamp(warmth - warmthStep, -100f, 100f);
//            colorGrading.temperature.value = warmth;
//        }
//        else if (Input.GetKeyDown(KeyCode.RightBracket))
//        {
//            warmth = Mathf.Clamp(warmth + warmthStep, -100f, 100f);
//            colorGrading.temperature.value = warmth;
//        }
//    }
//}
