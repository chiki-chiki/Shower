using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite bubbleSprite;
    [SerializeField] Sprite shineSprite; 
    [SerializeField]Vector3 maxScale;
    [SerializeField]Vector3 minScale;
    Sequence scaleSeqence;
        // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        scaleSeqence=DOTween.Sequence();
        ScaleTween();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void ScaleTween(){
        scaleSeqence.Append(transform.DOScale(maxScale,0.5f))
        .Append(transform.DOScale(minScale,1f))
        .SetLoops(-1,LoopType.Restart);
    }

    public void TargetClear(){
        //spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=shineSprite;
    }
    public void TargetReset(){
        //spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=bubbleSprite;
        Debug.Log("targeteffect.targetreset");
    }
    
    
}
