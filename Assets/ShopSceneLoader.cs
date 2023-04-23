using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSceneLoader : MonoBehaviour
{
    public List<ConversationPart.ItemAndAmount> conditions;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int numOfConditionsMet = 0;
            foreach (ConversationPart.ItemAndAmount condition in conditions)
            {
                foreach (ConversationPart.ItemAndAmount stockItem in StockManager.Stock)
                {
                    if (stockItem.item == condition.item && stockItem.amount >= condition.amount)
                    {
                        numOfConditionsMet++;
                        break;
                    }
                }
            }

            if (numOfConditionsMet == conditions.Count)
            {
                SceneManager.LoadScene("shopScene");
            }
        }
        
        
    }
}
