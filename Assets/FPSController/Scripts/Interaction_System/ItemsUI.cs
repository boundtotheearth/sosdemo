using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsUI : MonoBehaviour
{
    public TextMeshProUGUI clueName;
    public TextMeshProUGUI clueDescription;
    public RawImage clueImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(ClueData clueData)
    {
        clueName.SetText(clueData.clueName);
        clueDescription.SetText(clueData.clueDescription);
        clueImage.texture = clueData.clueImage;
    }
}
