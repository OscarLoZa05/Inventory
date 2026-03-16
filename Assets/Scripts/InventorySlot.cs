using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    public ScriptableItem slotItem;
    public int slotNumber;

    public GameObject inspectorWindow;
    public Image inspectionImage;
    public Text inspectionName;
    public Text inspectionPrice;
    public Text inspectionDescription;

    public Button thisSlotButton;
    public Button deleteButton;
    public Button closeButton;

    void Start()
    {
    thisSlotButton = GetComponentInChildren<Button>();
    thisSlotButton.onClick.AddListener(InspectName);        
    }

    void InspectName()
    {
        if(slotItem != null)
        {
            closeButton.onClick.AddListener(CloseWindow);
            deleteButton.onClick.AddListener(DeleteItem);

            inspectionImage.sprite =slotItem.itemSprite;
            inspectionName.text = slotItem.itemName;
            inspectionPrice.text = slotItem.itemSellPrice.ToString();
            inspectionDescription.text = slotItem.itemDescription;

            inspectorWindow.SetActive(true);
        }
    }

    void CloseWindow()
    {

    }

    void DeleteItem()
    {

    }

}