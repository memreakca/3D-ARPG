using UnityEngine;

public class NotificationEvents : MonoBehaviour
{
    public delegate void NotificationEventHandler(string message, Sprite icon);
    public static event NotificationEventHandler OnNotify;

    public static void Notify(string message, Sprite icon)
    {
        OnNotify?.Invoke(message, icon);
    }
}