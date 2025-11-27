using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
    /// <summary>
    /// This  calculates the expression and give the result 
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public string EvaluateCalculation(string expression)
    {
        if (string.IsNullOrEmpty(expression))
        {
            return "0";
        }

        List<string> expressionList = expression.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToList(); //Eg [1,+,2,*,8,/,7)
        
        // expressionList always the list will of odd size as 1 good expression contains 3 elements - left input, operator, right input
        if (expressionList.Count == 0 || expressionList.Count % 2 == 0) 
        {
            return "";
        }

        int index = 1; //starting with index 1 as operator will always be odd

        while (index < expressionList.Count - 1)
        {
            string op = expressionList[index];

            if (op == "÷" || op == "x")
            {
                //Tries to parse input into double data type
                if (!double.TryParse(expressionList[index - 1], out double leftInput) ||
                    !double.TryParse(expressionList[index + 1], out double rightInput))
                {
                    return "Error";
                }
                double currentResult = (op == "x") ? leftInput * rightInput : leftInput / rightInput;

                //Checks if result is either NaN or Inifinity
                if (double.IsNaN(currentResult)) {

                    return "NaN";
                }
                else if (double.IsInfinity(currentResult))
                {
                    return "Infinity";
                }


                expressionList[index - 1] = currentResult.ToString(System.Globalization.CultureInfo.InvariantCulture); //stores the result into left input
                expressionList.RemoveAt(index + 1);//Removed right input
                expressionList.RemoveAt(index); //Removes operator 
                index = System.Math.Max(1, index - 2);
            }
            //If current token is either + or - then we look for next token ie on + 2 position
            else
            {
                index += 2;
            }
        }

        index = 1;
        while (index < expressionList.Count - 1)
        {
            string op = expressionList[index];

            if (op == "+" || op == "-")
            {
                if (!double.TryParse(expressionList[index - 1], out double leftInput) ||
                    !double.TryParse(expressionList[index + 1], out double rightInput))
                {
                    return "Error";
                }
                double currentResult = (op == "+") ? leftInput + rightInput : leftInput - rightInput;

                expressionList[index - 1] = currentResult.ToString(System.Globalization.CultureInfo.InvariantCulture);
                expressionList.RemoveAt(index + 1);
                expressionList.RemoveAt(index);
                index = System.Math.Max(1, index - 2);
            }
            else
            {
                index += 2;
            }
        }
        // The  result should be in the first there should only be 1 token
        if (expressionList.Count == 1 && double.TryParse(expressionList[0], out double finalResult))
        {
            string displayResult = finalResult.ToString("G15", System.Globalization.CultureInfo.InvariantCulture);
            return displayResult;

        }
        else
        {
            return "Error";
        }
    }
}
