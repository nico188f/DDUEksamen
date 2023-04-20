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
		foreach (var item in ShopItemsList)

        {
			GameObject ShopItem = Instantiate(ItemTemplate, transform);
			ShopItem.GetComponent<ShopItemContainer>().InitializeShopItem(item);
        }


	}
}
