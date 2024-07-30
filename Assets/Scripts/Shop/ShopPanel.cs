using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPanel : MonoBehaviour
{
    public Button panelCloser;
    public Button buyPistol;
    public Button buySMG;
    ShopUIController shopUIController;
    [SerializeField]
    GameObject gunPlayer;
    [SerializeField]
    GameObject smgPlayer;

    [SerializeField]
    bool gunBought = false;
    [SerializeField]
    bool smgBought = false;


    void Start()
    {
        shopUIController = GetComponentInParent<ShopUIController>();
        panelCloser.onClick.AddListener(() => CloseShopPanel());
        buyPistol.enabled = false;
        buySMG.enabled = false;
        buyPistol.onClick.AddListener(() => CurrentPlayerFinder(gunPlayer));
        buySMG.onClick.AddListener(() => CurrentPlayerFinder(smgPlayer));
    }

    
    void Update()
    {
        CheckBuyable();
    }

    void CloseShopPanel()
    {
        this.gameObject.SetActive(false);
    }

    void CurrentPlayerFinder(GameObject WhatYouBought)
    {
        GameObject currentplayer = GameObject.FindGameObjectWithTag("Player");
        Transform spawnpoint = currentplayer.transform;
        Destroy(currentplayer);
        Instantiate(WhatYouBought, spawnpoint);
        if(WhatYouBought == gunPlayer)
        {
            gunBought = true;
        }
        if(WhatYouBought == smgPlayer)
        {
            smgBought = true;
        }
    }

    void CheckBuyable()
    {
        if(shopUIController.coinCount >= 3 && gunBought == false)
        {
            buyPistol.enabled = true;
        }
        if(shopUIController.coinCount >= 7 && smgBought == false)
        {
            buySMG.enabled = true;
        }
        if(shopUIController.coinCount < 3)
        {
            buyPistol.enabled = false;
            buySMG.enabled = false;
        }
    }

}
