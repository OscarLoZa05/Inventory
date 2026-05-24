using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InfinteInventoryManager : MonoBehaviour
{
    public static InfinteInventoryManager Instance;

    void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        _inventorycanvasTransform = GameObject.Find("Inventory").transform;
    }

    public List<ScriptableObject> items;
    public GameObject slotPrefab;

    private Transform _inventorycanvasTransform;


    public void AddItem(ScriptableItem item)
    {
        GameObject prefab = Instantiate(slotPrefab);
        prefab.transform.SetParent(_inventorycanvasTransform);

        InfiniteInventorySlot prefabScript = prefab.GetComponent<InfiniteInventorySlot>();
        prefabScript.slotItem = item;

        items.Add(item);
    }
}