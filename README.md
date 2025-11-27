# Unity Calculator (DMAS Based)
A calculator build with unity which evaluates long expressions correctly using **DMAS** operator precedence, and has dotween animation.

---

## Features

- Supports Additon, Subtraction, Multiplication, Division
- Evaluates full expressions with **DMAS** rules
- Left-to-right order 
- Displays:
  - Current expression
  - Final result after evaluation
- Clear → clears current input  
- Reset → clears full expression + result
- DOTween **punch-scale** animation on button press

---

## How It Works
- Input is built as a full expression string  
- Expression is split into **numbers** and **operators**
- Two-pass custom evaluation:
  1. Handle **×** and **÷**
  2. Handle **+** and **–**

---

## Tech Used
- Unity  
- C#  
- TextMeshPro  
- DOTween  

---

## How to Run
1. Open the project in Unity  
2. Open **GameScene**  
3. Press **Play**

