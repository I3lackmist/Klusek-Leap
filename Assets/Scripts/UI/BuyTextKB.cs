using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTextKB : MonoBehaviour
{
    
    void Update()
    {
        if(PlayerPrefs.GetInt("KBBought") == 1) {
            Destroy(gameObject);    
        }    
    }
}
