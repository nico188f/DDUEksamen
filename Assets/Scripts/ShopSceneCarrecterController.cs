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
    public Vector3 FocusPoint;

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

    public DialogHandler dialogHandler;



    private void Start()
    {
        FocusPoint = CenterPoint.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    private void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, FocusPoint, ref velocity, smoothTime, speed);

        if (transform.position.x >= CenterPoint.position.x-1 && transform.position.x <= CenterPoint.position.x + 1)
        {
            isOnCenter = true;
        }
        else
        {
            isOnCenter = false;
        }

        if (transform.position.x >= RightPoint.position.x - 1)
        {
            dialogHandler.aConversationIsActive = false;
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
        FocusPoint = CenterPoint.position;
    }
    public void CharecterMoveOut()
    {
        FocusPoint = RightPoint.position;
    }
}
