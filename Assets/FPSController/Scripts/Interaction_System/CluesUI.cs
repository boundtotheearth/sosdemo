using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesUI : MonoBehaviour
{
    public ItemsUI itemsUI;
    public MemoriesUI memoriesUI;
    public bool isOpen;

    public int itemsIndex = 0;
    public int memoriesIndex = 0;

    [SerializeField] private ClueManager clueManager;
    [SerializeField] private ExamineUI examineUI;
    private List<ClueData> discoveredItems;
    private List<ClueData> discoveredMemories;

    // Start is called before the first frame update
    void Start()
    {
        CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToggleMenu()
    {
        if(isOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        discoveredItems = clueManager.GetDiscoveredItems();
        discoveredMemories = clueManager.GetDiscoveredMemories();

        UpdateItemsMenu();
        UpdateMemoriesMenu();

        gameObject.SetActive(true);
        isOpen = true;
    }

    public void ToggleItems(bool isOpen)
    {
        OpenMenu();
        itemsUI.gameObject.SetActive(isOpen);
    }

    public void ToggleMemories(bool isOpen)
    {
        OpenMenu();
        memoriesUI.gameObject.SetActive(isOpen);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        isOpen = false;
    }

    public void ScrollPrevItem()
    {
        itemsIndex -= 1;
        UpdateItemsMenu();
    }

    public void ScrollNextItem()
    {
        itemsIndex += 1;
        UpdateItemsMenu();
    }

    private void UpdateItemsMenu()
    {
        if(itemsIndex <= 0)
            itemsIndex = 0;
        
        if(itemsIndex >= discoveredItems.Count)
            itemsIndex = discoveredItems.Count - 1;

        itemsUI.UpdateUI(discoveredItems[itemsIndex]);
    }

    public void ScrollPrevMemory()
    {
        memoriesIndex -= 1;
        UpdateMemoriesMenu();
    }

    public void ScrollNextMemory()
    {
        memoriesIndex += 1;
        UpdateMemoriesMenu();
    }

    private void UpdateMemoriesMenu()
    {
        if(memoriesIndex < 0)
            memoriesIndex = 0;
        
        if(memoriesIndex >= discoveredMemories.Count)
            memoriesIndex = discoveredMemories.Count - 1;

        memoriesUI.UpdateUI(discoveredMemories[memoriesIndex]);
    }

    public void GoToExamine()
    {
        Debug.Log(discoveredItems[itemsIndex]);
        examineUI.SetExamineObject(discoveredItems[itemsIndex]);
    }
}
