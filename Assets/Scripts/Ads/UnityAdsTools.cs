using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Tools
{
    internal class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
        private string _gameId = "4279637";
        private string _videoId = "video";


        private Action _callbackSuccessShowVideo;

        private void Start()
        {
            Advertisement.Initialize(_gameId);
        }

        public void ShowVideo()
        {
            Advertisement.Show(_videoId);
        }

        public void OnUnityAdsReady(string placementId)
        {

        }

        public void OnUnityAdsDidError(string message)
        {

        }

        public void OnUnityAdsDidStart(string placementId)
        {

        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Skipped)
                Debug.Log("Skipped");
                //_callbackSuccessShowVideo?.Invoke();
        }
    }
}