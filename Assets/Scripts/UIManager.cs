using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    Text turnText = null;
    private void OnEnable()
    {
        GameManager.turnPassedEvent += UpdateTurnText;
    }

    private void OnDisable()
    {
        GameManager.turnPassedEvent -= UpdateTurnText;
    }

    void UpdateTurnText()
    {
        turnText.text = "Turn: " + GameManager.Instance.currentTurn;
    }
}
