using Doublsb.Dialog;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    public DialogManager dialogManager;
    void Start()
    {
        var testSelect = new DialogData("Do you like icecream?");
        testSelect.SelectList.Add("good", "Yes");
        testSelect.SelectList.Add("Thats a lie", "No");
        testSelect.SelectList.Add("Yes you do", "I dont know");


    }

        }
    }
}