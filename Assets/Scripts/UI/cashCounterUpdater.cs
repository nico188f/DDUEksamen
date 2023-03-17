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
        updateCashCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousCash != CashManager.cash)
        {
            updateCashCounter();
            previousCash = CashManager.cash;
        }
    }

    private void updateCashCounter()
    {
        text.text = CashManager.cash.ToString() + "$";
    }
}
