using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClueManager : MonoBehaviour
{

    [SerializeField] private List<ClueData> discoveredItems;
    [SerializeField] private List<ClueData> discoveredMemories;

    // Start is called before the first frame update
    void Start()
    {
        discoveredItems = new List<ClueData>();
        discoveredMemories = new List<ClueData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddClue(ClueData clueData)
    {
        if(clueData.clueType == ClueType.Item)
        {
            if(!discoveredItems.Contains(clueData))
            {
                discoveredItems.Add(clueData);
            }
        }
        else if(clueData.clueType == ClueType.Memory)
        {
            if(!discoveredMemories.Contains(clueData))
            {
                discoveredMemories.Add(clueData);
            }
        }
    }

    public List<ClueData> GetDiscoveredItems()
    {
        return discoveredItems;
    }

    public List<ClueData> GetDiscoveredMemories()
    {
        return discoveredMemories;
    }
}
