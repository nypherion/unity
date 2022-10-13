using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float dist, speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xpos = transform.position.x + dist;
        Vector3 target = new Vector3(xpos, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        if (transform.position.x >= dist) Destroy(gameObject);
    }

    public void MoveForward(uint dist, uint speed)
    {
        this.dist = dist;
        this.speed = speed;
    }
}
