using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopSceneCarrecterController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Transform LeftPoint;
    public Transform CenterPoint;
    public Transform RightPoint;
    public Transform FocusPoint;

    public float speed;

    public float smoothTime = 0.5f;
    Vector3 velocity;

    [Serializable]
    public class Character
    {
        public string name;
        public Sprite Sprite;
    }

    public List<Character> characters;

    public bool isOnCenter = false;

    private void Start()
    {
        FocusPoint = CenterPoint;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    private void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, FocusPoint.position, ref velocity, smoothTime, speed);

        if (transform.position == CenterPoint.position)
        {
            isOnCenter = true;
        }
        else
        {
            isOnCenter = false;
        }
    }
    public void CharecterMoveIn(string name)
    {
        
        foreach (Character character in characters)
        {
            if (character.name == name)
            {
                spriteRenderer.sprite = character.Sprite;
                break;
            }
        }

        transform.position = LeftPoint.position;
        FocusPoint.position = CenterPoint.position;
    }
    public void CharecterMoveOut()
    {
        FocusPoint.position = RightPoint.position;
    }
}
