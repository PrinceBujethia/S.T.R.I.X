using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRNotificationManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI registeredIssueText;
    public GameObject notificationPanel;
    public GameObject issuePanel;

    [Header("Audio")]
    public AudioSource notificationSound;

    [Header("Timers (in seconds)")]
    public float eyeRednessTimer = 10f;
    public float headacheTimer = 15f;
    public float seizureTimer = 20f;
    public float alertRepeatInterval = 5f;

    private Dictionary<KeyCode, string> problemMapping;
    private bool alertsEnabled = false;
    private Coroutine alertCoroutine;
    private bool alertFeatureEnabled = false;


    void Start()
    {
        problemMapping = new Dictionary<KeyCode, string>()
        {
            { KeyCode.Alpha1, "Eye Redness" },
            { KeyCode.Alpha2, "Headache" },
            { KeyCode.Alpha3, "Seizure" }
        };

        notificationPanel.SetActive(false);
        issuePanel.SetActive(false);
    }

    void Update()
    {
        // register issues
        foreach (var entry in problemMapping)
            if (Input.GetKeyDown(entry.Key))
                RegisterIssue(entry.Value);
    }

    void RegisterIssue(string issue)
    {
        registeredIssueText.text = "Registered Issue: " + issue;
        StartCoroutine(ShowIssuePanel());
    }

    IEnumerator ShowIssuePanel()
    {
        issuePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        issuePanel.SetActive(false);
        registeredIssueText.text = "";
    }

    IEnumerator AlertRoutine()
    {
        // initial delay
        float maxDelay = Mathf.Max(eyeRednessTimer, headacheTimer, seizureTimer);
        float t = 0f;
        while (alertsEnabled && t < maxDelay)
        {
            t += Time.deltaTime;
            yield return null;
        }
        if (!alertsEnabled) yield break;

        // repeating alerts
        while (alertsEnabled)
        {
            TriggerAlert();
            float dt = 0f;
            while (alertsEnabled && dt < alertRepeatInterval)
            {
                dt += Time.deltaTime;
                yield return null;
            }
        }
    }

    void TriggerAlert()
    {
        notificationText.text = "A";
        notificationPanel.SetActive(true);
        if (notificationSound != null && !notificationSound.isPlaying)
            notificationSound.Play();
    }

    public void EnableAlerts(bool manual = false)
    {
        if (!alertsEnabled)
        {
            alertsEnabled = true;
            alertCoroutine = StartCoroutine(AlertRoutine());
        }
    }

    public void DisableAlerts(bool manual = false)
    {
        if (alertsEnabled)
        {
            alertsEnabled = false;
            if (alertCoroutine != null)
                StopCoroutine(alertCoroutine);
            notificationPanel.SetActive(false);
            notificationText.text = "";
        }
    }

    /// <summary>
    /// Toggles alert on/off
    /// </summary>
    public void ToggleAlerts()
    {
        if (alertsEnabled) DisableAlerts();
        else EnableAlerts();
    }

    public bool AreAlertsEnabled() => alertsEnabled;

    public void ToggleAlertFeature()
    {
        alertFeatureEnabled = !alertFeatureEnabled;
    }

    public bool IsAlertFeatureEnabled()
    {
        return alertFeatureEnabled;
    }

}
