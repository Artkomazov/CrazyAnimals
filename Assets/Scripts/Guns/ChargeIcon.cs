using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    public Image Background;
    public Image Foreground;
    public Text Text;

    public void StartCharge()
    {
        Background.color = new(1f, 1f, 1f, 0.2f);
        Foreground.enabled = true;
        Text.enabled = true;
    }
    public void StopCharge()
    {
        Background.color = new(1f, 1f, 1f, 1f);
        Foreground.enabled = false;
        Text.enabled = false;
    }
    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        Foreground.fillAmount = currentCharge / maxCharge;
        Text.text = (maxCharge-currentCharge).ToString("0");
    }
}
