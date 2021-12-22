using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashing : MonoBehaviour
{
    public float force = 100f;
    public float dashCooldown = 0.3f;
    float timer = 0f;
    Rigidbody2D rb;
    public ParticleSystem trail;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButtonDown("DashLeft") && timer >= dashCooldown)
        {
            trail.Play();
            timer = 0f;
            rb.AddForce(new Vector2(-force, 0f));
        }
        if (Input.GetButtonDown("DashRight") && timer >= dashCooldown)
        {
            trail.Play();
            timer = 0f;
            rb.AddForce(new Vector2(force, 0f));
        }

        if(timer >= 0.2f && trail.isPlaying)
        {
            trail.Stop();
        }
    }
}
