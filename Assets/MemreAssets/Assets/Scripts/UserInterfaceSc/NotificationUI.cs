using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Image iconImage;

    public void SetNotification(string message, Sprite imageSprite)
    {
        if (imageSprite == null)
        {
            iconImage.color = new Color(0, 0, 0, 0);
        }
        else
        {
            iconImage.color = new Color(1, 1, 1, 1);
        }
        messageText.text = message;
        iconImage.sprite = imageSprite;
    }

    public void CloseNotification()
    {
        Destroy(gameObject);
    }
}
