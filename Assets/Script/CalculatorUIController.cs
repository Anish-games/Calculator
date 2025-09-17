using TMPro;
using UnityEngine;

public class CalculatorUIController : MonoBehaviour
{
    public TextMeshProUGUI expressionText;
    public TextMeshProUGUI resultText;

    private CalculatorEngine engine = new CalculatorEngine();

    public void PressNumber(string number)
    {
        engine.AddNumber(number);
        UpdateDisplay();
    }

    public void PressOperator(string op)
    {
        engine.AddOperator(op);
        UpdateDisplay();
    }

    public void PressClear()
    {
        engine.Clear();
        expressionText.text = "";
        resultText.text = "";
    }

    public void PressEquals()
    {
        resultText.text = engine.GetResult();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        expressionText.text = engine.GetExpression();
    }
}
