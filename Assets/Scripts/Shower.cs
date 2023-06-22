using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shower : MonoBehaviour
{
    [SerializeField]WaterHoll[] waterHolls;
    public float waterPower;
    bool isStart;
    bool isFixed;

    AudioSource audioSource;
    [SerializeField]AudioClip fixSound;
    [SerializeField]AudioClip showerStartSound;
    [SerializeField]AudioClip showerSound;

    Sequence showerSoundSeqence;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }
	void Update()
	{
        if(!isStart&&!isFixed){
            var pos = Camera.main.WorldToScreenPoint (transform.localPosition);
		    var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos );
		    transform.localRotation = rotation;
        }
		
	}

    public void showerStart(){
        isStart=true;
        for(int i=0;i<waterHolls.Length;i++){
            waterHolls[i].waterPower=waterPower;
            waterHolls[i].showerStart();
            audioSource.PlayOneShot(showerStartSound);
            audioSource.Play();
        }
    }
    float volume;
    public void showerStop(){
        isStart=false;
        isFixed=false;
        for(int i=0;i<waterHolls.Length;i++){
            waterHolls[i].showerStop();
        }
        volume=audioSource.volume;
        audioSource.DOFade(0,1f);
        Invoke("showerSoundReset",1.1f);

    }
    void showerSoundReset(){
        Debug.Log("showerSoundREset");
        audioSource.Stop();
        audioSource.volume=volume;
        Debug.Log(audioSource.volume);
        Debug.Log(volume);
    }

    public void fixUnFixAxis(){
        isFixed=!isFixed;
        if(isFixed){
            audioSource.PlayOneShot(fixSound);
            transform.localScale=transform.localScale*1.1f;
            transform.DOScale(transform.localScale/1.1f,0.5f);
            isFixed=true;

        }
    }
}
