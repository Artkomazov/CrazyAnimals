using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    private int lastUnlockLevel;
    private void Start()
    {
        if (levelButtons != null)
        {
            // �������� ������ ���������� ����������� ������ �� PlayerPrefs, �� ��������� ��� 1 (������ �������)
            lastUnlockLevel = PlayerPrefs.GetInt("lastUnlockLevel", 1);

            // ���������� ������ ������ �� ���������� ����������� ������
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i < lastUnlockLevel)
                {
                    levelButtons[i].interactable = true;
                }
                else
                {
                    levelButtons[i].interactable = false;
                }
            }
        }
        
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void NextLevel()
    {
        lastUnlockLevel = PlayerPrefs.GetInt("lastUnlockLevel");
        SceneManager.LoadScene(lastUnlockLevel);
    }

    public void UnlockLevel(int levelIndex)
    {
        // ���� ������� ������� ��������� ������ ���������� ����������� ������, ��������� �������� � PlayerPrefs
        if (levelIndex > PlayerPrefs.GetInt("lastUnlockLevel", 1))
        {
            PlayerPrefs.SetInt("lastUnlockLevel", levelIndex);
            PlayerPrefs.Save();
        }
    }

    public void ResetGameProgress()
    {
        PlayerPrefs.SetInt("lastUnlockLevel", 1);
        PlayerPrefs.Save();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < 1)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
