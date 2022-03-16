using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject starLabel;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public float delayTime;

    public void StartStarAnimation(float point)
    {
        starLabel.SetActive(true);

        if(point < 40f)
        {
            StartCoroutine(ThreeStar());
        }

        if(point >= 40f && point < 50f)
        {
            StartCoroutine(TwoStar());
        }

        if(point >= 50f && point < 75f)
        {
            StartCoroutine(OneStar());
        }
    }

    IEnumerator OneStar()
    {
        yield return new WaitForSeconds(delayTime);
        star1.SetActive(true);
    }

    IEnumerator TwoStar()
    {
        yield return new WaitForSeconds(delayTime);
        star1.SetActive(true);

        yield return new WaitForSeconds(delayTime);
        star2.SetActive(true);
    }

    IEnumerator ThreeStar()
    {
        yield return new WaitForSeconds(delayTime);
        star1.SetActive(true);

        yield return new WaitForSeconds(delayTime);
        star2.SetActive(true);

        yield return new WaitForSeconds(delayTime);
        star3.SetActive(true);
    }
}
