using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartStopButton : MonoBehaviour
{
    bool isStart;
    [SerializeField]TextMeshProUGUI buttonText;
    [SerializeField]Shower shower;
    [SerializeField]LevelManager levelManager;
    float showerTimeCount;
    [SerializeField] float waterPowerMax;
    [SerializeField]Slider waterPowerSlider;
    [SerializeField]float showerTimeCountMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart){
            showerTimeCount+=Time.deltaTime;
        }
        if(showerTimeCount>=showerTimeCountMax){
            isStart=false;
            buttonText.text="START";
            shower.showerStop();
            showerTimeCount=0;
        }
    }

    public void startStop(){
        if(!isStart){
            buttonText.text="STOP";
            shower.waterPower=waterPowerMax*waterPowerSlider.value;
            shower.showerStart();
            if(!levelManager.isClear){
                levelManager.TargetReset();
            }
            isStart=true;
        }
        else{
            buttonText.text="START";
            shower.showerStop();
            if(!levelManager.isClear){
                levelManager.TargetReset();
            }
            isStart=false;
        }
        showerTimeCount=0;

    }
}
