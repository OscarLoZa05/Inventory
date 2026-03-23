using UnityEngine;
using UnityEngine.UI;
public class InfiniteInventorySlot : MonoBehaviour
{

    public ScriptableItem slotItem;
    private Text itemNameText;
    private Image itemImage;


    //Ventana de Inspeccion de objetos
    public GameObject inspectorWindow;
    public Image inspectionImage;
    public Text inspectionName;
    public Text inspectionPrice;
    public Text inspectionDescription;

    public Button thisSlotButton;
    public Button deleteButton;
    public Button closeButton;

    void Awake()
    {

        itemNameText = GetComponentInChildren<Text>();
        itemImage = GetComponentInChildren<Image>();
        
        GameObject canvas = GameObject.Find("Canvas");

        inspectorWindow = canvas.transform.Find("InspectWindows").gameObject;
        inspectionImage = inspectorWindow.transform.Find("Item Image").GetComponent<Image>();
        inspectionName = inspectorWindow.transform.Find("Item Name").GetComponent<Text>();
        inspectionDescription = inspectorWindow.transform.Find("Item Description").GetComponent<Text>();
        inspectionPrice = inspectorWindow.transform.Find("Item Price").GetComponent<Text>();

        closeButton = inspectorWindow.transform.Find("Close Button").GetComponent<Button>();
        deleteButton = inspectorWindow.transform.Find("Delete Button").GetComponent<Button>();

        thisSlotButton = GetComponentInChildren<Button>();
        thisSlotButton.onClick.AddListener(InspectName);
    }

    void Start()
    {
        itemNameText.text = slotItem.itemName;
        itemImage.sprite = slotItem.itemSprite;
    }

    void InspectName()
    {
        if(slotItem != null)
        {
            deleteButton.onClick.RemoveAllListeners();

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
        inspectorWindow.SetActive(false);

        closeButton.onClick.RemoveListener(CloseWindow);
        deleteButton.onClick.RemoveListener(DeleteItem);
    }

    void DeleteItem()
    {
        InfinteInventoryManager.Instance.items.Remove(slotItem);

        CloseWindow();

        Destroy(gameObject);
    }
}