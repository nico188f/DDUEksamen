using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterDialog : MonoBehaviour
{
    bool isFirstTimeSpokenTo = true;

    public DialogHandler DialogHandler;

    public ConversationPart FirstConversation;
    public ConversationPart SecondConversation;
    public Item itemToGive;
    public GameObject ItemPrefab;

    public void Interact()
    {
        if (isFirstTimeSpokenTo)
        {
            isFirstTimeSpokenTo = false;
            DialogHandler.RunConversationPart(FirstConversation);
            GameObject tempGO = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
            tempGO.GetComponent<DroppedItem>().item = itemToGive;
            tempGO.GetComponent<SpriteRenderer>().sprite = itemToGive.sprite;
        }
        else
        {
            DialogHandler.RunConversationPart(SecondConversation);
        }
    }
}
