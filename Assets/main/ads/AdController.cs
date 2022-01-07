using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdController : MonoBehaviour
{

    private BannerView bannerAd;

    private string testBanner = "ca-app-pub-3940256099942544/6300978111";

    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });

        bannerAd = new BannerView(testBanner,AdSize.Banner,AdPosition.Top);

        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerAd.LoadAd(adRequest);
    }
}
