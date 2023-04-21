using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using static ConversationPart;
using UnityEngine.Events;

public class DialogHandler : MonoBehaviour
{
    public DialogManager DialogManager;
    public ConversationPart TestConversation;

    public ConversationPart FocusConversationPart;

    public List<DialogData> dialogTexts = new List<DialogData>();


    private void Awake()
    {
        if (TestConversation != null)
        {
            RunConversation(TestConversation);
        }
    }
    public void RunConversation(ConversationPart conversationpart)
    {
        dialogTexts.Clear();
        FocusConversationPart = conversationpart;
        foreach (string nPCDialog in FocusConversationPart.DialogList)
        {
            dialogTexts.Add(new DialogData(nPCDialog));
        }
        if (FocusConversationPart.ResponceList.Count > 0)
        {
            for (int i = 0; i < FocusConversationPart.ResponceList.Count; i++)
            {
                Responce responce = FocusConversationPart.ResponceList[i];
                dialogTexts[dialogTexts.Count - 1].SelectList.Add(i.ToString(), responce.responceMessage);
            }
            
            
        }
        dialogTexts[dialogTexts.Count - 1].Callback = () => Check_Correct();

        Debug.Log("npssmv");
        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        Debug.Log("Rip");
        if (FocusConversationPart.OnConversation != null)
        {
            FocusConversationPart.OnConversation.Invoke();
            
        }
        if (FocusConversationPart.ResponceList.Count > 0)
        {
            for (int i = 0; i < FocusConversationPart.ResponceList.Count; i++)
            {
                Responce responce = FocusConversationPart.ResponceList[i];
                if (DialogManager.Result == i.ToString())
                {
                    if (responce.NPCResponce != null)
                    {
                        Debug.Log("Rip2");
                        RunConversation(responce.NPCResponce);
                        Debug.Log("Rip3");
                        return;
                    }
                    else break;
                }
            }
        }
        Debug.Log("Rip4");
    }
}
