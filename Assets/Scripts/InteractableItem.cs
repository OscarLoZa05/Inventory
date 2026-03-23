using UnityEngine;

public class InteractableItem : MonoBehaviour
{

    public ScriptableItem item;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        spriteRenderer.sprite = item.itemSprite;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        InfinteInventoryManager.Instance.AddItem(item);
        //InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }
}
