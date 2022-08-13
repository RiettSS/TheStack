using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdInitializer : MonoBehaviour
{
    private void Awake()
    {
        MobileAds.Initialize(status => {} );
    }
}
