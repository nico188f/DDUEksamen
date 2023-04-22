using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSceneManager : MonoBehaviour
{
    public ShopItemSpawner shopItemSpawner;
    public DialogHandler DialogHandler;

    public List<ConversationPart> ConversationsToRun;

    private void Update()
    {
        if (shopItemSpawner.activeShopItems == 0 && !DialogHandler.aConversationIsActive)
        {
            if (ConversationsToRun.Count > 0)
            {
                DialogHandler.StartNewConvosation(ConversationsToRun[0]);
                ConversationsToRun.RemoveAt(0);
            }
            else
            {
                //switch scene
            }
        }
    }



}
