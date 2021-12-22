using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limittoscreen : MonoBehaviour
{
    
    private Vector2 scrBounds;
    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        scrBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        width = GetComponent<SpriteRenderer>().bounds.size.x /2f;
        height = GetComponent<SpriteRenderer>().bounds.size.y /2f;
    }


    /*
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, scrBounds.x + width, scrBounds.x * -1 - width);
        pos.y = Mathf.Clamp(pos.y, scrBounds.y + height, scrBounds.y * -1 - height);
        transform.position = pos;
    }
    */



    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -scrBounds.x + width, scrBounds.x - width), Mathf.Clamp(transform.position.y, -scrBounds.y + height, scrBounds.y - height), transform.position.z);
    }
}
