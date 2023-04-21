using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
	#region Singlton:Shop

	public static Shop Instance;

	

	#endregion
	
	public List<Item> ShopItemsList = new List<Item>();
	[SerializeField] Animator NoCoinsAnim;


	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform ShopScrollView;
	[SerializeField] GameObject ShopPanel;
	Button buyBtn;

	void Start()
	{
		int i = 0;
		foreach (var item in ShopItemsList)
        {
			StockManager.Stock.Add(new ConversationPart.ItemAndAmount(item, 0));


			GameObject ShopItem = Instantiate(ItemTemplate, transform);
			ShopItem.GetComponent<ShopItemContainer>().stockIndex = i;
			i++;
			ShopItem.GetComponent<ShopItemContainer>().InitializeShopItem(item);
        }


	}
}
