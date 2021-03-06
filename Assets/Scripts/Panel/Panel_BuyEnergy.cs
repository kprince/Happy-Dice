﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_BuyEnergy : PanelBase
{
    public Button btn_ad;
    const int adEnergy = 10;
    int clickAdTime = 0;
    protected override void Awake()
    {
        base.Awake();
        btn_ad.onClick.AddListener(OnAdClick);
    }
    void OnAdClick()
    {
        AudioManager.Instance.PlayerSound("Button");
        clickAdTime++;
        Ads._instance.ShowRewardVideo(OnRewardedCallback, clickAdTime, "buy dice energy");
    }
    void OnRewardedCallback()
    {
        GameManager.Instance.AddEnergy(adEnergy);
    }
    protected override void Close()
    {
        base.Close();
        AudioManager.Instance.PlayerSound("Button");
        PanelManager.Instance.ClosePanel(PanelType.BuyEnergy);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        clickAdTime = 0;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public override void OnExit()
    {
        base.OnExit();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
