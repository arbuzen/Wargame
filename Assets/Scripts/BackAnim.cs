using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAnim : MonoBehaviour
{
    public RectTransform selfRect;
    private Sequence animSequence;
    
    [Header("Settings")]
    public float alphaSpeed;
    public float scaleSpeed;
    public float moveScale;
    
    [Header("Easing Functions")]
    public Ease alphaEase = Ease.Linear; 
    public Ease scaleEase = Ease.Linear;
    
    public void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        CanvasGroup selfRectAlpha = selfRect.GetComponent<CanvasGroup>();

        selfRectAlpha.alpha = 0;
        selfRect.localScale = new Vector3(moveScale, moveScale, moveScale);
    }
    
    public void StartAnim()
    {
        CanvasGroup selfRectAlpha = selfRect.GetComponent<CanvasGroup>();
        
        animSequence = DOTween.Sequence();

        animSequence.Append(selfRectAlpha.DOFade(1, alphaSpeed).SetEase(alphaEase))
        .Insert(0, selfRect.DOScale(1f, scaleSpeed).SetEase(scaleEase));
    }
}
