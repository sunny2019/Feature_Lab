using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    private Material mat_Circle;
    private bool timePause = false;
    private bool scaling = false;
    private float scaleValue = 0;
    private float scaleSpeed = 1;

    public Animator animator_Player;
    
    // Start is called before the first frame update
    void Start()
    {
        mat_Circle = this.GetComponent<Renderer>().material;
        mat_Circle.SetFloat("_Scale", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (scaling)
        {
            if (timePause)
            {
                scaleValue += Time.deltaTime * scaleSpeed;
                mat_Circle.SetFloat("_Scale",scaleValue);
                if (scaleValue>5)
                {
                    scaling = false;
                }
            }
            else
            {
                scaleValue -= Time.deltaTime * scaleSpeed;
                mat_Circle.SetFloat("_Scale",scaleValue);
                if (scaleValue<=0.01)
                {
                    animator_Player.speed =  1;
                    mat_Circle.SetFloat("_Scale",scaleValue);
                    scaling = false;
                }
            }

            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            timePause = !timePause;
            scaling = true;
            if (timePause)
            {
                animator_Player.speed = 0;
            }
            
        }
    }
}
