using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBTN : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("topDownScene");
    }
}
