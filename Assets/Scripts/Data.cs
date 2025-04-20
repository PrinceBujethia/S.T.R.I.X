using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour
{
    public UDPReceive udpReceive;
    public Camera mainCamera;
    public VRNotificationManager notificationManager;
    public Image warmTintImage;

    [Header("UI")]
    public GameObject featureStatusPanel;
    public TextMeshProUGUI statusText;

    [Header("FOV Settings")]
    public float defaultFOV = 60f;
    public float reducedFOV = 40f;            // new target instead of 45
    public float fovTransitionSpeed = 20f;

    private float warmthLevel = 0f;
    private bool fovFeatureEnabled = false;
    private bool warmthTintEnabled = false;
    private Coroutine panelHideCoroutine;

    void Start()
    {
        if (featureStatusPanel != null)
            featureStatusPanel.SetActive(false);
    }

    void Update()
    {
        string status = udpReceive.data; // Replace this with udpReceive.data
        Debug.Log("Status: " + status);

        // FOV toggle
        if (Input.GetKeyDown(KeyCode.F))
        {
            fovFeatureEnabled = !fovFeatureEnabled;
            ShowFeatureStatus("FOV Feature: " + (fovFeatureEnabled ? "ON" : "OFF"));
        }

        // Tint toggle
        if (Input.GetKeyDown(KeyCode.T))
        {
            warmthTintEnabled = !warmthTintEnabled;
            ShowFeatureStatus("Warm Tint: " + (warmthTintEnabled ? "ON" : "OFF"));
        }

        // Toggle alert feature manually with A key
        if (Input.GetKeyDown(KeyCode.A) && notificationManager != null)
        {
            notificationManager.ToggleAlertFeature(); // this just flips the enabled flag
            ShowFeatureStatus("Alert: " + (notificationManager.IsAlertFeatureEnabled() ? "ON" : "OFF"));
        }

        // Actual alert behavior only triggers during "slow"
        if (status == "slow")
        {
            if (notificationManager.IsAlertFeatureEnabled())
                notificationManager.EnableAlerts(); // start alerting
            else
                notificationManager.DisableAlerts(); // user disabled it
        }
        else
        {
            notificationManager.DisableAlerts(); // always stop alerting outside "slow"
        }

        // Determine FOV target
        float targetFOV = defaultFOV;
        if ((status == "fast" || status == "abnormal") && fovFeatureEnabled)
            targetFOV = reducedFOV;

        // Smoothly move current FOV toward target
        if (mainCamera != null)
        {
            mainCamera.fieldOfView = Mathf.MoveTowards(
                mainCamera.fieldOfView,
                targetFOV,
                fovTransitionSpeed * Time.deltaTime
            );
        }

        // FOV and tint visuals
        switch (status)
        {
            case "slow":
                if (mainCamera != null && fovFeatureEnabled)
                    mainCamera.fieldOfView = 60;
                warmthLevel = 0f;
                break;

            case "normal":
                if (mainCamera != null && fovFeatureEnabled)
                    mainCamera.fieldOfView = 60;
                warmthLevel = 0f;
                break;

            case "fast":
                    
                warmthLevel = 0f;
                break;

            case "abnormal":
                
                warmthLevel = warmthTintEnabled
                    ? Mathf.Clamp01(warmthLevel + 0.02f)
                    : 0f;
                break;

            default:
                warmthLevel = 0f;
                break;
        }

        UpdateOverlay();
    }



    void UpdateOverlay()
    {
        if (warmTintImage != null)
            warmTintImage.color = new Color(1f, 0.6f, 0.3f, warmthLevel * 0.1f);
    }

    void ShowFeatureStatus(string message)
    {
        if (featureStatusPanel != null)
            featureStatusPanel.SetActive(true);

        if (statusText != null)
            statusText.text = message;

        if (panelHideCoroutine != null)
            StopCoroutine(panelHideCoroutine);
        panelHideCoroutine = StartCoroutine(HidePanelAfter(2f));
    }

    IEnumerator HidePanelAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (featureStatusPanel != null)
            featureStatusPanel.SetActive(false);
    }
}
