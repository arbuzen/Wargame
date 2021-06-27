using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnim : MonoBehaviour
{
    public UniformAnim topMenu;
    public UniformAnim mainMenu;
    public UniformAnim header;
    public UniformAnim premiumButton;
    public UniformAnim quests;
    public BackAnim background;

    public float delay;

    private Sequence startSequence;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sequence TweenIn = DOTween.Sequence();
            TweenIn.InsertCallback(0.2f, StartAnim);
        }
    }
    
    public void StartAnim()
    {
        background.Reset();
        topMenu.Reset();
        mainMenu.Reset();
        header.Reset();
        premiumButton.Reset();
        quests.Reset();
        
        int i = 0;

        startSequence = DOTween.Sequence();
        startSequence.AppendInterval(0.5f)
            .InsertCallback(delay * (i++), background.StartAnim)
            .InsertCallback(delay * (i++), topMenu.StartAnim)
            .InsertCallback(delay * (i++), mainMenu.StartAnim)
            .InsertCallback(delay * (i++), header.StartAnim)
            .InsertCallback(delay * (i++), premiumButton.StartAnim)
            .InsertCallback(delay * (i++), quests.StartAnim);
    }
    
}
