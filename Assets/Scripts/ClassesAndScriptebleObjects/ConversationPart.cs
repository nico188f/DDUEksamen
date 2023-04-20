using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Scriptable Object/Create New Conversation")]
public class ConversationPart : ScriptableObject
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
        public List<ItemAndAmount> RequiredItems = new List<ItemAndAmount>();
        public int RequiredAmountOfMoney;

        [Header("Next step")]
        public ConversationPart NPCResponce;
    }
    [Serializable]
    public class NPCDialog
    {
        public string message;
        public string carecterName;
    }

    public List<NPCDialog> DialogList = new List<NPCDialog>();

    [Header("Reward")]
    public List<ItemAndAmount> Rewards = new List<ItemAndAmount>();
    public int cashReward;

    [Header("Next Step")]
    public UnityEvent OnConversation;
    public List<Responce> ResponceList = new List<Responce>();
}
