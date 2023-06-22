using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
    LevelManager levelManager;
    public bool isClear;
    TargetEffect[]targetEffects;
    SpriteRenderer spriteRenderer;
    [SerializeField]Sprite bubbledSprite;
    [SerializeField]Sprite cleanSprite;
    Sequence scaleSeqence;
    // Start is called before the first frame update
    void Start()
    {
        levelManager=transform.parent.gameObject.GetComponent<LevelManager>();
        targetEffects=new TargetEffect[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            targetEffects[i]=transform.GetChild(i).gameObject.GetComponent<TargetEffect>();
        }
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isClear){
            TargetClear();
            
        }
    }
    public void TargetClear(){
        //sprite変更
        spriteRenderer.sprite=cleanSprite;
        //カチッと感
        transform.localScale*=1.1f;
        transform.DOScale(transform.localScale/1.1f,0.5f);

        levelManager.TargetClear();

        isClear=true;

        for(int i=0;i<targetEffects.Length;i++){
            targetEffects[i].TargetClear();
        }

    }
    public void TargetReset(){
        Debug.Log("target.targetreset");
        isClear=false;
        spriteRenderer.sprite=bubbledSprite;
        for(int i=0;i<targetEffects.Length;i++){
            targetEffects[i].TargetReset();
        }
    }
}
