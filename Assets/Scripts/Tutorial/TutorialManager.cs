using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] Hints;

    public void OpenHint(int index)
    {
        Time.timeScale = 0f;
        Hints[index].gameObject.SetActive(true);
    }

    public void CloseHint(int index)
    {
        Time.timeScale = 1f;
        Hints[index].gameObject.SetActive(false);
    }
}
