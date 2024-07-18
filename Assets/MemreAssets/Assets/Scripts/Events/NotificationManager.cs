using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public GameObject notificationPrefab;
    public Transform notificationPanel;

    public GameObject DeathPanel;

    void OnEnable()
    {
        NotificationEvents.OnNotify += HandleNotification;
        PlayerEvents.OnPlayerDeath += OnPlayerDeath;
        PlayerEvents.OnPlayerRespawn += OnPlayerRespawn;
    }

    void OnDisable()
    {
        NotificationEvents.OnNotify -= HandleNotification;
        PlayerEvents.OnPlayerDeath -= OnPlayerDeath;
        PlayerEvents.OnPlayerRespawn -= OnPlayerRespawn;
    }

    private void HandleNotification(string message, Sprite icon)
    {
        GameObject notificationObject = Instantiate(notificationPrefab, notificationPanel);
        NotificationUI notificationUI = notificationObject.GetComponent<NotificationUI>();

        if (notificationUI != null)
        {
            notificationUI.SetNotification(message, icon);
        }
        else
        {
            Debug.LogWarning("Notification UI component not found on prefab.");
        }

        Destroy(notificationObject, 2f);
    }

    private void OnPlayerDeath()
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    private void OnPlayerRespawn()
    {
        DeathPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}