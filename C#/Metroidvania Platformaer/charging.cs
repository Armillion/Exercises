using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charging : MonoBehaviour
{
    Stats staty;                        //objekt naszych statystyk
    Vector3 previousPosision;           //posision we were on the last frame
    public float rate = 10f;            //regain health after this amount of seconds
    float timer = 0f;                   //timer used to count seconds in movement

    private void Start()
    {
        staty.GetComponent<Stats>();
        previousPosision = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(previousPosision != transform.position)
        {
            timer += Time.deltaTime;
            if(timer >= rate)
            {
                staty.Health++;
            }
        }
        else
        {
            timer = 0f;
        }
        previousPosision = transform.position;
    }
}
