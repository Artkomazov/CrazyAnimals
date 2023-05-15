using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsOnTrigger : MonoBehaviour
{
    public int HintIndex;

    private TutorialManager _tutorialManager;
    private  Menu _menu;
    private bool _isUsed = false;

    private void Start()
    {
        _menu = FindObjectOfType<Menu>();
        _tutorialManager = FindObjectOfType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.GetComponentInParent<PlayerMove>();
        if (playerMove != null)
        {
            if (!_isUsed)
            {
                _menu.OpenMenuWindow();
                _menu.MenuWindow.SetActive(false);
                _tutorialManager.OpenHint(HintIndex);
                _isUsed = true;
            }
        }
    }
}
