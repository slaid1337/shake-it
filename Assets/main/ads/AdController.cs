using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdController : MonoBehaviour
{

    private BannerView bannerAd;
    private InterstitialAd interstitialAd;

    private string key = "ca-app-pub-2117946503817885~7226040326";

    private string testBanner = "ca-app-pub-3940256099942544/6300978111";
    private string testAd = "ca-app-pub-3940256099942544/1033173712";

    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });

        bannerAd = new BannerView(key, AdSize.Banner,AdPosition.Top);
        AdRequest adRequest = new AdRequest.Builder().Build();
        bannerAd.LoadAd(adRequest);

        interstitialAd = new InterstitialAd(key);
        AdRequest adRequest1 = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest1);

    }

    public void ShowAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }
}
