using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    playerMove player;
    Text distanseText; 
    private void Awake() 
    {
        player = GameObject.Find("Player").GetComponent<playerMove>();
        distanseText=GameObject.Find("DistanceText").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanseText.text = distance + " m";
    }
}
