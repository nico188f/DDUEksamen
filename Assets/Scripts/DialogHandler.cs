using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public class DialogHandler : MonoBehaviour
{
    public DialogManager DialogManager;
    public ConversationPart TestConversation;

    public ConversationPart Conversation;



    private void Awake()
    {
        RunConversation(TestConversation);
    }
    public void RunConversation(ConversationPart conversationpart)
    {
        List<DialogData> dialogTexts = new List<DialogData>();

        for (int i = 0; i < conversationpart.DialogList.Count - 1; i++)
        {
            dialogTexts.Add(new DialogData(conversationpart.DialogList[i].message, conversationpart.DialogList[i].carecterName));
        }
        
        
        
        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("You are right."));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("You are wrong."));

            DialogManager.Show(dialogTexts);
        }
        else
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Right. You don't have to get the answer."));

            DialogManager.Show(dialogTexts);
        }
    }
}
