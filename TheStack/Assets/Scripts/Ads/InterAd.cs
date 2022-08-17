using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ads
{
    public class InterAd
    {
        public event Action Closed;
        
        private InterstitialAd _interstitial;
        private const string ID = "ca-app-pub-3940256099942544/8691691433";

        public InterAd()
        {
            _interstitial = new InterstitialAd(ID);
            AdRequest adRequest = new AdRequest.Builder().Build();
            _interstitial.LoadAd(adRequest);
            _interstitial.OnAdClosed += OnAdClosed;
        }
        
        public void Show()
        {
            if (_interstitial.IsLoaded())
            {
                _interstitial.Show();
            }
            else
            {
                
            }
        }
        
        private void OnAdClosed(object sender, EventArgs e)
        {
            //Closed?.Invoke();
            //SceneManager.LoadScene("Scenes/GameScreen");
        }

    }
}
