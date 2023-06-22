using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]RectTransform fixButton;
    [SerializeField]RectTransform startStopButton;
    [SerializeField]RectTransform powerSlider;
    [SerializeField]RectTransform powerText;
    [SerializeField]RectTransform clearText;
    [SerializeField]RectTransform NextButton;
    [SerializeField]RectTransform kira1;
    [SerializeField]RectTransform kura2;

    [SerializeField]RectTransform transitionBubble;

    Sequence levelClearSeqence;
    Sequence nextButtonSeqence;

    [SerializeField]string nextStageName;


    // Start is called before the first frame update
    void Start()
    {
        transitionBubble.localScale=Vector3.one;
        transitionBubble.DOScale(Vector3.zero,1f);

        levelClearSeqence=DOTween.Sequence();
        nextButtonSeqence=DOTween.Sequence();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void levelClear(){
        fixButton.localScale=Vector3.zero;
        startStopButton.localScale=Vector3.zero;
        powerSlider.localScale=Vector3.zero;
        powerText.localScale=Vector3.zero;

        
        levelClearSeqence.Append(clearText.DOScale(Vector3.one,0.5f))
        .Join(kira1.DOScale(Vector3.one,0.5f))
        .Join(kura2.DOScale(Vector3.one,0.5f))
        .Append(NextButton.DOScale(Vector3.one*0.7f,0.5f));

        levelClearSeqence.Play();

    }

    public void NextButtonPush(){
        transitionBubble.DOScale(Vector3.one,1f);
        Invoke("LoadNextStage",1f);
        //nextButtonSeqence.Play();
    }
    void LoadNextStage(){
        SceneManager.LoadScene(nextStageName);

    }
}
