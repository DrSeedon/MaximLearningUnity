using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class AllCoroutines : MonoBehaviour
{
    float time = 0f;
    public Color readyColor;
    public Color unreadyColor;

    public TMP_Text textTimer;
    public TMP_Text textFirst;
    public TMP_Text textSecond;
    public TMP_Text textThird;
    public TMP_Text textFourth;
    public TMP_Text textA;
    public TMP_Text textB;
    public TMP_Text textSixth;
    public TMP_Text textInformator;
    public TMP_Text textInformator2;

    public bool isSecondReady = false;
    public bool isThirdUnready = true;
    public bool isAFinished = false;
    public string stringInformator;
    public string stringInformator2;

    public Coroutine informatorRoutine;
    public Coroutine informatorRoutine2;
    private void Start()
    {
        if (informatorRoutine2 == null)
        {
            informatorRoutine2 = StartCoroutine(InformatorRoutine2(textInformator2));
            Debug.Log("InformatorRoutine2 started");
        }
    }
    void StartAllCoroutines()
    {
        StartCoroutine(Timer(textTimer));
        StartCoroutine(FirstCoroutine(textFirst));
        StartCoroutine(SecondCoroutine(textSecond));
        StartCoroutine(ThirdCoroutine(textThird));
        StartCoroutine(FourthCoroutine(textFourth));
        StartCoroutine(BCoroutine(textB));
        StartCoroutine(SixthCoroutine(textSixth));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (informatorRoutine == null)
            {
                informatorRoutine = StartCoroutine(InformatorRoutine(textInformator));
                Debug.Log("InformatorRoutine started");
            }
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (informatorRoutine != null)
            {
                StopCoroutine(informatorRoutine);
                Debug.Log("InformatorRoutine stopped");
                informatorRoutine = null;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartAllCoroutines();
        }
    }


    private IEnumerator Timer(TMP_Text text)
    {
        text.color = readyColor;
        while (true)
        {
            text.text = "Timer: " + time.ToString("0.00");
            time += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private IEnumerator FirstCoroutine(TMP_Text text)
    {
        text.color = unreadyColor;
        while (time < 3f)
        {
            text.text = "First Coroutine time = " + time.ToString("0.00");
            yield return new WaitForSeconds(0.01f);
        }
        text.color = readyColor;
        Debug.Log("First Coroutine finished");
    }
    private IEnumerator SecondCoroutine(TMP_Text text)
    {
        text.color = unreadyColor;
        while (!isSecondReady)
        {
            text.text = "Second Coroutine: unready";
            yield return new WaitForSeconds(0.01f);
        }
        text.text = "Second Coroutine: ready";
        text.color = readyColor;
        Debug.Log("Second Coroutine finished");
    }
    private IEnumerator ThirdCoroutine(TMP_Text text)
    {
        text.color = unreadyColor;
        for (; isThirdUnready;)
        {
            text.text = "Third Coroutine: unready";
            yield return new WaitForSeconds(0.01f);
        }        
        text.text = "Third Coroutine: ready";
        text.color = readyColor;
        Debug.Log("Third Coroutine finished");
    }
    private IEnumerator FourthCoroutine(TMP_Text text)
    {
        text.color = unreadyColor;
        while (time < 3f)
        {
            text.text = "Fourth Coroutine time = " + time.ToString("0.00");
            yield return null;
        }
        text.color = readyColor;
        Debug.Log("Fourth Coroutine finished");
    }
    private IEnumerator ACoroutine(TMP_Text text)
    {
        text.color = unreadyColor;
        while (time < 5f)
        {
            text.text = "A Coroutine time = " + time.ToString("0.00");
            yield return new WaitForSeconds(0.01f);
        }
        text.color = readyColor;
        isAFinished = true;
        Debug.Log("A Coroutine finished");
    }
    private IEnumerator BCoroutine(TMP_Text text)
    {
        StartCoroutine(ACoroutine(textA));
        text.color = unreadyColor;
        while (!isAFinished)
        {
            text.text = "Waiting for A Coroutine";
            yield return new WaitForSeconds(0.01f);
        }
        text.color = readyColor;
        Debug.Log("B Coroutine finished");
    }
    private IEnumerator SixthCoroutine(TMP_Text text)
    {
        text.color = unreadyColor;
        while (time < 2f)
        {
            text.text = "Sixth Coroutine time = " + time.ToString("0.00");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("Sleep for 5 seconds");
        Thread.Sleep(5000);
        text.color = readyColor;
        Debug.Log("Sixth Coroutine finished");
    }
    private IEnumerator InformatorRoutine(TMP_Text text)
    {
        text.color = readyColor;
        text.text = "InformatorRoutine started: \n";
        int count = 0;
        while (true)
        {
            text.text += count++ + ": " + stringInformator + "\n";
            yield return new WaitForSeconds(2f);
        }
    }
    private IEnumerator InformatorRoutine2(TMP_Text text)
    {
        text.color = readyColor;
        text.text = "InformatorRoutine2 started: \n";
        int count = 0;
        while (true)
        {
            text.text += count++ + ": " + stringInformator2 + "\n";
            yield return new WaitForSeconds(2f);
        }
    }
}
