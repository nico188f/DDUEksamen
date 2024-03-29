using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour

{
    public GameObject ExitPoint;
    public GameObject Player;

    public int index;
    public string LevelName;

    public Image black; 
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        Player.transform.position = new Vector2(ExitPoint.transform.position.x, ExitPoint.transform.position.y);
        anim.SetBool("Fade", false);

    }
}