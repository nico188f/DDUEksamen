using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Scriptable Object/Create New Conversation")]
public class DialogMessage : ScriptableObject
{
    [Serializable]
    public class ItemAndAmount
    {
        public Item item;
        public int amount;
    }
    [Serializable]
    public class Responce
    {
        public string responceMessage;

        [Header("Requirement for responce")]
        public ItemAndAmount RequiredItems;
        public int RequiredAmountOfMoney;

        [Header("Next step")]
        public DialogMessage NPCResponce;
        [Tooltip("If you are in a nested conversation you can navigate out by using this list.")]
        public List<int> NPCResponceIndex = new List<int>();
    }
    
    public string NPCDialog;
    public string carecterName;

    [Header("Reward")]
    public List<ItemAndAmount> Rewards = new List<ItemAndAmount>();
    public int cashReward;

    [Header("Next Step")]
    public UnityEvent OnConversation;

    public List<Responce> Responces = new List<Responce>();
    [Tooltip("If you are in a nested conversation you can navigate out by using this list.")]
    public List<int> NextConversationPartIndex = new List<int>();
}