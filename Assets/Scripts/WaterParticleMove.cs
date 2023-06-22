using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleMove : MonoBehaviour
{
    public float waterPower;
    public Vector3 showerAxis;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(showerAxis*waterPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
