using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    PlayerCntroller cntroller;
    public float rate = 0.05f;
    public float maxRate = 1.5f;
    public ParticleSystem trail;
    [SerializeField]float adding = 1f;
    float startSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cntroller = GetComponent<PlayerCntroller>();
        startSpeed = cntroller.runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Sprint") != 0)
        {
            if(!trail.isPlaying)
            {
                trail.Play();
            }
            if(adding < maxRate)
            {
                cntroller.runSpeed = startSpeed * adding;
                adding += (rate * Time.deltaTime);
            }
        }
        else
        {
            if(trail.isPlaying)
            {
                trail.Stop();
            }
            cntroller.runSpeed = startSpeed;
            adding = 1f;
        }
    }

    private void LateUpdate()
    {
        if (Input.GetAxisRaw("Sprint") != 0)
            cntroller.jump = false;
    }

}
