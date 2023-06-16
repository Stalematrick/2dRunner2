using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundscrtpt : MonoBehaviour
{
    public float groundHeight;
    BoxCollider2D colliders;
    public void Awake()
    {
        colliders = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y+ (colliders.size.y /2);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
