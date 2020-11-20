using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public bool isPlayerInventory;
    private void Awake()
    {
		gameObject.SetActive(false);
	}

	public void OpenCloseInventory()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}

	public void LoadInventory(List<GameObject> playerItens)
	{
		Image[] itens = transform.GetChild(0).GetChild(0).GetComponentsInChildren<Image>();
			Debug.Log(itens.Length);

    	for (int i = 0; i < playerItens.Count; i++)
		{
			itens[i + 1].sprite = playerItens[i].gameObject.GetComponent<ItemInterface>().GetSprite();
			Debug.Log(itens[i].gameObject.name);
		}
	
	}
}
