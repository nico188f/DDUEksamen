using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cashCounterUpdater : MonoBehaviour
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
        if (previousCash != cashManager.cash)
        {
            updateCashCounter();
            previousCash = cashManager.cash;
        }
    }

    private void updateCashCounter()
    {
        text.text = cashManager.cash.ToString() + "$";
    }
}
