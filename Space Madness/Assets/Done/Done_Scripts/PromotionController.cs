using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PromotionController : MonoBehaviour
{
    public GameObject Banner;
    public float SleepTime;

    private bool _isBannerShown = false;

    void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("PromotionSmall"));
    }

    void Update()
    {
        if ((AppCore.CurrentStatus == AppCore.Status.FAST_GAME_OVER ||
             AppCore.CurrentStatus == AppCore.Status.RESTART_FAST_GAME))
        {
            if (_isBannerShown == false)
            {
                _isBannerShown = true;
                Debug.Log("promotion created");
                StartCoroutine(WaitThenShow());
            }
        }
        else
        {
            if (_isBannerShown)
            {
                _isBannerShown = false;
                Destroy(GameObject.FindGameObjectWithTag("PromotionBig"));
            }
        }
    }

    IEnumerator WaitThenShow()
    {
        yield return new WaitForSeconds(SleepTime);
        var banner = Instantiate(Banner, Vector3.zero, Quaternion.identity);
        Destroy(banner, 7);
    }
}

