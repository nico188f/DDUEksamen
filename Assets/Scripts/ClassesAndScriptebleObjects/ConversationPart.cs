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
        public ItemAndAmount(Item item, int amount)
        {
            this.item = item;
            this.amount = amount;
        }
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

    public string carecterName;
    public List<string> DialogList = new List<string>();

    [Header("Reward")]
    public List<ItemAndAmount> Rewards = new List<ItemAndAmount>();
    public int cashReward;

    [Header("Next Step")]
    public UnityEvent OnConversation;
    public List<Responce> ResponceList = new List<Responce>();
}
