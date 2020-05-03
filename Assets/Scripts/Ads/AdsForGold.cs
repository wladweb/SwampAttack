using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsForGold : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject _startWatchingButton;

    private string _gameId = "3585785";
    private string _myPlacementId = "rewardedVideo";
    private bool _testMode = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        _startWatchingButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(_myPlacementId);
            _startWatchingButton.SetActive(false);
        });
    }

    public void OnUnityAdsDidError(string message)
    {}

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Reward");
        }
        else if (showResult == ShowResult.Failed)
        {
            //
        }
        else if (showResult == ShowResult.Skipped)
        { 
            //
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {}

    public void OnUnityAdsReady(string placementId)
    {
        if (_myPlacementId == placementId)
        {
            _startWatchingButton.SetActive(true);
        }
    }
}
