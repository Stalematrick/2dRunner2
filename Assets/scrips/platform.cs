using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float depth = 1;
    playerMove player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<playerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;
        pos.x -= realVelocity *Time.fixedDeltaTime;
        if(pos.x<= -40)
            pos.x = 40;
        transform.position= pos;
    }
}
