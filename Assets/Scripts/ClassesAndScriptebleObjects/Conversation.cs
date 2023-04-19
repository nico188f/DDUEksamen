using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Scriptable Object/Create New Conversation")]
public class Conversation : ScriptableObject
{
    public List<DialogMessage> ConversationParts = new List<DialogMessage>();

}
