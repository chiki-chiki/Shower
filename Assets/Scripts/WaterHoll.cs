using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHoll : MonoBehaviour
{
    public float waterPower;
    [SerializeField]GameObject WaterParticle;
    [SerializeField]WaterParticleMove waterParticleMove;
    [SerializeField]Rigidbody2D waterParticleRb;
    GameObject _waterParticle;
    [SerializeField]Transform ShowerAxisPivot;
    GameObject waterParticleParent;
    bool isStart;
    int waterGenerateSpan=2;
    int frameCount;

    
    void FixedUpdate()
    {
        if(isStart){
            //_waterParticle=Instantiate(WaterParticle,transform.position,Quaternion.identity);
            //_waterParticle.get.AddForce(transform.forward*waterPower);
            //Instantiate(WaterParticle,waterParticleParent.transform.position,Quaternion.identity,waterParticleParent.transform);
            frameCount++;
            if(frameCount>=waterGenerateSpan){
                Instantiate(WaterParticle,waterParticleParent.transform);
                frameCount=0;
            }
        }
        //Instantiate(WaterParticle,transform.position,Quaternion.identity);
    }
    public void showerStart(){
        waterParticleMove.showerAxis=(transform.position-ShowerAxisPivot.position).normalized;
        waterParticleMove.waterPower=this.waterPower;
        Destroy(waterParticleParent);
        waterParticleParent=Instantiate(new GameObject("waterParticleParent"),transform.position,Quaternion.identity,this.gameObject.transform);
        isStart=true;
    }
    public void showerStop(){
        waterParticleParent.transform.parent=null;
        isStart=false;
    }
}
