using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopUIController : MonoBehaviour
{
    public TMP_Text coinText;
    public int coinCount = 0;
    public GameObject shopPanel;
    public Button shopPanelButton;
    void Start()
    {
        shopPanelButton.onClick.AddListener(() => OpenShopPanel());
        DontDestroyOnLoad(this.gameObject);
    }

    
    void Update()
    {
        UpdateCoinInUI();
    }

    void UpdateCoinInUI()
    {
        coinText.text = "Coin : " + coinCount;
    }
    void OpenShopPanel()
    {
        shopPanel.SetActive(true);
        
    }

}
