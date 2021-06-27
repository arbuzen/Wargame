using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformAnim : MonoBehaviour
{
    public RectTransform selfRect;
    private Sequence animSequence;
    private Vector3 selfRectPos;
    
    [Header("Reset Position")]
    public float movePosX;
    public float movePosY;
    public float moveScale;
    public float moveDelay;
    
    [Header("Settings")]
    public float alphaSpeed;
    public float moveSpeed;
    public float scaleSpeed;
    
    [Header("Easing Functions")]
    public Ease alphaEase = Ease.Linear;
    public Ease moveEase = Ease.Linear;
    public Ease scaleEase = Ease.Linear;
    
    public bool showExtraAnim;
    public bool showSoloTest;
    
    public void Awake()
    {
        selfRectPos = new Vector3(selfRect.localPosition.x, selfRect.localPosition.y, selfRect.localPosition.z);

        Reset();
    }

    public void Reset()
    {
        CanvasGroup selfRectAlpha = selfRect.GetComponent<CanvasGroup>();

        selfRectAlpha.alpha = 0;
        selfRect.localPosition = new Vector3(selfRectPos.x + movePosX, selfRectPos.y + movePosY, selfRectPos.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && showSoloTest != false)
        {
            Debug.Log("UniformAnim.Update.StartAnim");
            Reset();
            
            Sequence TweenIn = DOTween.Sequence();
            TweenIn.InsertCallback(0.2f, StartAnim);
        }
    }

    public void StartAnim()
    {
        CanvasGroup selfRectAlpha = selfRect.GetComponent<CanvasGroup>();
        
        animSequence = DOTween.Sequence();
        animSequence.Append(selfRectAlpha.DOFade(1, alphaSpeed).SetEase(alphaEase))
        .Insert(0, selfRect.DOLocalMove(selfRectPos, moveSpeed).SetEase(moveEase));
        ExtraAnim(showExtraAnim);
    }
    
    public void ExtraAnim(bool show)
    {
        int objectCount = selfRect.childCount;
        
        if (show != false)
        {  
            for (int i = 0; i < objectCount; i++)
            {
                Transform countObject = selfRect.transform.GetChild(i);
                CanvasGroup countObjectAlpha = countObject.GetComponent<CanvasGroup>();

                countObject.localScale = new Vector3(moveScale, moveScale, moveScale);
                countObjectAlpha.alpha = 0;

                countObjectAlpha.DOFade(1, alphaSpeed).SetDelay(moveDelay * i).SetEase(alphaEase);
                countObject.DOScale(1, scaleSpeed).SetDelay(moveDelay * i).SetEase(scaleEase);
            }
        }
    }
}