using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnim : MonoBehaviour
{
    public RectTransform self;
    public UniformAnim topMenu;
    public UniformAnim mainMenu;
    public UniformAnim header;
    public UniformAnim premiumButton;
    public UniformAnim quests;
    public BackAnim background;

    public float delay;
    public bool showSoloTest;

    private Sequence animSequence;

    void Awake()
    {
        self.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && showSoloTest != false)
        {
            Debug.Log("MainAnim.Update.StartAnim");
            Sequence TweenIn = DOTween.Sequence();
            TweenIn.InsertCallback(0.2f, StartAnim);
        }
    }

    public void Reset()
    {
        CanvasGroup selfAlpha = self.GetComponent<CanvasGroup>();
        self.gameObject.SetActive(false);
        selfAlpha.alpha = 1;
    }

    public void StartAnim()
    {
        Debug.Log("MainAnim.StartAnim");

        self.gameObject.SetActive(true);
        background.Reset();
        topMenu.Reset();
        mainMenu.Reset();
        header.Reset();
        premiumButton.Reset();
        quests.Reset();

        int i = 0;

        animSequence = DOTween.Sequence();
        animSequence.AppendInterval(0.5f)
            .InsertCallback(delay * (i++), background.StartAnim)
            .InsertCallback(delay * (i++), topMenu.StartAnim)
            .InsertCallback(delay * (i++), header.StartAnim)
            .InsertCallback(delay * (i++), quests.StartAnim)
            .InsertCallback(delay * (i++), mainMenu.StartAnim)
            .InsertCallback(delay * (i++), premiumButton.StartAnim);
    }
    
    public void EndAnim()
    {
        CanvasGroup selfAlpha = self.GetComponent<CanvasGroup>();

        animSequence = DOTween.Sequence();
        animSequence.Append(selfAlpha.DOFade(0, 0.2f).SetEase(Ease.OutExpo))
            .OnComplete(() => { Reset(); });
    }
}
