using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    private string _currentInput;
    private string _expressionInput;

    private void OnEnable()
    {
        _currentInput = "0";
        if(_uiManager==null)
        {
            _uiManager = GetComponent<UIManager>();
        }
    }

    /// <summary>
    /// Calls when numbers are pressed 
    /// </summary>
    /// <param name="number"></param>
    public void OnNumberClick(string number)
    {
        if (_currentInput == "0")
            _currentInput = "";
        _currentInput += number;
        UpdateUI();
    }

    /// <summary>
    /// Called when operators are clicked +,-,/,*
    /// </summary>
    /// <param name="op"></param>
    public void OnOperatorClick(string op)
    {
        if (string.IsNullOrEmpty(_currentInput))
        {
            if (!string.IsNullOrEmpty(_expressionInput)) //This specifies there's an operator in the end
            {
                if (_expressionInput.Length < 3)
                    return;

                string lastChar = _expressionInput[_expressionInput.Length - 2].ToString();
                if (lastChar == op) //checks if input operator is same
                    return;

                _expressionInput = _expressionInput.Substring(0, _expressionInput.Length - 3);
                _expressionInput += " " + op + " "; //replaces with new one
                UpdateUI();
                return;
            }
            return;
        }
        _expressionInput += _currentInput + " " + op + " ";
        _currentInput = "";
        UpdateUI();
    }

    /// <summary>
    /// Clears current input
    /// </summary>
    public void OnClear()
    {
        _currentInput = "";
        UpdateUI();
    }

    /// <summary>
    /// Clears everything
    /// </summary>
    public void OnClearAll()
    {
        _currentInput = "0";
        _expressionInput = "";
        UpdateUI();
    }

    public void UpdateUI()
    {
        _uiManager.UpdateInputDisplay(_expressionInput + _currentInput);
    }

}
