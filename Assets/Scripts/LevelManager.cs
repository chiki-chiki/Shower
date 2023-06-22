using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelManager : MonoBehaviour
{
    int clearTargetsNum;
    int toralTargetsNum;
    public bool isClear;

    Target[]targets;
    AudioSource audioSource;
    [SerializeField]AudioClip clearSound;

    [SerializeField]UIManager uIManager;
    
    // Start is called before the first frame update
    void Start()
    {
        targets=new Target[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            targets[i]=transform.GetChild(i).GetComponent<Target>();
        }
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clearTargetsNum>=targets.Length&&!isClear){
            Debug.Log(clearTargetsNum);
            LevelClear();
        }
    }
    public void TargetClear(){
        clearTargetsNum++;
    }
    public void TargetReset(){
        Debug.Log("targetreset");
        for(int i=0;i<targets.Length;i++){
            targets[i].TargetReset();
        }
        clearTargetsNum=0;
    }
    void LevelClear(){
        Debug.Log("clear");
        isClear=true;
        audioSource.PlayOneShot(clearSound);
        uIManager.levelClear();
    }

}
