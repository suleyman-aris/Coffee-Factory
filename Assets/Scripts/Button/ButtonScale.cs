using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonScale : MonoBehaviour
{
    private Button button;
    public float wait = 0.01f;
    private Vector3 targetSize;
    private Vector3 startSize;
    private Vector3 targetRot;
    private Vector3 startRot;
    private void Awake()
    {
        button = transform.GetComponent<Button>();
        startSize = button.transform.localScale;
        targetSize = button.transform.localScale - new Vector3(0.3f, 0.3f, 0.3f);
        startRot = button.transform.eulerAngles;
        targetRot = button.transform.eulerAngles + new Vector3(0, 0, 5);
    }

    private RectTransform rectTransform;
    private void Start()
    {
        if (gameObject.name == "Sell Button")
        {
            rectTransform = GetComponent<RectTransform>();
            StartScaleAnimation();
        }
    }

    private void StartScaleAnimation()
    {
        // �lk �l�ek de�erini belirliyoruz
        //rectTransform.localScale = Vector3.one * 2.2f;
        targetSize = button.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
        // Sonsuz d�ng�yle tekrar eden animasyon
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(targetSize, wait + 1f));
        sequence.Append(transform.DOScale(startSize, wait + 1f));
        sequence.SetLoops(-1);
    }

    public void Scale()
    {

        button.transform.DOScale(targetSize, wait).OnComplete(() =>
        {
            button.transform.DORotate(targetRot, wait).OnComplete(() =>
            {
                button.transform.DOScale(startSize, wait).OnComplete(() =>
                {
                    button.transform.DORotate(startRot, wait);
                });
            });
        });
    }


    //private void Update()
    //{


    //    if (gameObject.name == "Sell Button" && SortOnTray.sortOnTray.coffeCount >= 1)
    //    {
    //        button.transform.DOScale(targetSize, wait)
    //.SetLoops(-1) // Sonsuz d�ng�
    //.SetEase(Ease.Linear) // Easing ayar� (iste�e ba�l�)
    //.OnComplete(() =>
    //{
    //    button.transform.DOScale(startSize, wait);
    //});
    //        //button.transform.DOScale(targetSize, wait).OnComplete(() =>
    //        //{
    //        //    button.transform.DOScale(startSize, wait);
    //        //});
    //    }
    //}
}
