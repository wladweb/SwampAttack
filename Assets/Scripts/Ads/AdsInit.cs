using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string gameId = "3585785";
    private bool testMode = true;

    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    private IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("MainBottom"))
        {
            yield return new WaitForSeconds(.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("MainBottom");
    }
}
