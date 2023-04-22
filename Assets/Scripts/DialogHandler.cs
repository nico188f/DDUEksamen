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
    public bool ConversationShouldStartWhenCharecterIsReady = false;

    public ShopSceneCarrecterController shopSceneCarrecterController;
    public DialogManager DialogManager;
    public ConversationPart TestConversation;
    public ShopItemSpawner shopItemSpawner;


    public ConversationPart FocusConversationPart;

    public List<DialogData> dialogTexts = new List<DialogData>();

    public bool aConversationIsActive = false;

    private void Update()
    {
        if (shopSceneCarrecterController.isOnCenter && ConversationShouldStartWhenCharecterIsReady)
        {
            ConversationShouldStartWhenCharecterIsReady = false;
            RunConversationPart(FocusConversationPart);
        }
    }


    private void Awake()
    {
        if (TestConversation != null)
        {
            StartNewConvosation(TestConversation);
        }
    }

    public void StartNewConvosation(ConversationPart conversationpart)
    {
        aConversationIsActive = true;

        FocusConversationPart = conversationpart;
        if (conversationpart.isStartOfConversation)
        {
            shopSceneCarrecterController.CharecterMoveIn(conversationpart.carecterName);
        }
        
        ConversationShouldStartWhenCharecterIsReady = true;
    }

    public void RunConversationPart(ConversationPart conversationpart)
    {
        dialogTexts.Clear();
        FocusConversationPart = conversationpart;
        foreach (string nPCDialog in FocusConversationPart.DialogList)
        {
            dialogTexts.Add(new DialogData(nPCDialog, "Nicolaj"));
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

        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        if (FocusConversationPart.ResponceList.Count > 0)
        {
            for (int i = 0; i < FocusConversationPart.ResponceList.Count; i++)
            {
                Responce responce = FocusConversationPart.ResponceList[i];
                if (DialogManager.Result == i.ToString())
                {
                    if (responce.ShopItemsToSpawnOn.Count > 0)
                    {
                        shopItemSpawner.SpawnShopItem(responce.ShopItemsToSpawnOn);
                    }

                    if (responce.NPCResponce != null)
                    {
                        RunConversationPart(responce.NPCResponce);
                        return;
                    }
                    else break;
                }
            }
        }
        if (FocusConversationPart.ShopItemsToSpawnOn.Count > 0)
        {
            shopItemSpawner.SpawnShopItem(FocusConversationPart.ShopItemsToSpawnOn);
        }
        if (FocusConversationPart.NextConversation != null)
        {
            RunConversationPart(FocusConversationPart.NextConversation);
            return;
        }
        if (FocusConversationPart.isEndOfConversation)
        {
            shopSceneCarrecterController.CharecterMoveOut();
        }
        else
        {
            aConversationIsActive = false;
        }
        
    }
}
