using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashCounterUpdater : MonoBehaviour
{
    public TextMeshProUGUI text;
    int previousCash;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCashCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousCash != CashManager.cash)
        {
            UpdateCashCounter();
            previousCash = CashManager.cash;
        }
    }

    private void UpdateCashCounter()
    {
        text.text = CashManager.cash.ToString() + "$";
    }
}
