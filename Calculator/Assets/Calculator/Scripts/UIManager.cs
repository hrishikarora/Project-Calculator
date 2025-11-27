using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Text References")]
    public TextMeshProUGUI _expressionText;
    public TextMeshProUGUI _inputText;
    public TextMeshProUGUI _resultText;


    // Updates the full expression UI 
    public void UpdateExpressionDisplay(string expression)
    {
        if (_expressionText != null)
            _expressionText.text = expression;
    }


    // Updates the input UI
    public void UpdateInputDisplay(string input)
    {
        if (_inputText != null)
            _inputText.text = input;
    }

    // Updated result UI
    public void UpdateResultDisplay(string result)
    {
        if (_resultText != null)
            _resultText.text = result;
    }
}
