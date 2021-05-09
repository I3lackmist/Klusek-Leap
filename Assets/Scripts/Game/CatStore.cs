using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CatStore : MonoBehaviour {
    [SerializeField] GameObject[] cats;
    [SerializeField] int[] prices;
    [SerializeField] GameObject player;
    GameObject current_cat;
    void Start() {
        int cat_choice = PlayerPrefs.GetInt("CatChoice");
        current_cat = Instantiate(cats[cat_choice], player.transform);
        StartCoroutine(player.GetComponent<PlayerLaunch>().resetSprend());
    }

    void setCat(int n) {
        Destroy(current_cat);
        current_cat = Instantiate(cats[n], player.transform);
        StartCoroutine(player.GetComponent<PlayerLaunch>().resetSprend());
    }

    public void chooseKlusek() {
        PlayerPrefs.SetInt("CatChoice", 0);
        setCat(0);
    }

    public void chooseSonia() {
        if (PlayerPrefs.GetInt("SoniaBought") == 0) {
            if (PlayerPrefs.GetInt("Coins") >= prices[1]) {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - prices[1]);
                PlayerPrefs.SetInt("SoniaBought", 1);
                PlayerPrefs.SetInt("CatChoice", 1);

                setCat(1);
            }
        }
        else {
            PlayerPrefs.SetInt("CatChoice", 1);

            setCat(1);
        }
    }

    public void chooseKlusekBandana() {
        if (PlayerPrefs.GetInt("KBBought") == 0) {
            if (PlayerPrefs.GetInt("Coins") >= prices[2]) {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - prices[2]);
                PlayerPrefs.SetInt("KBBought", 1);
                PlayerPrefs.SetInt("CatChoice", 2);

                setCat(2);
            }
        }
        else {
           
            PlayerPrefs.SetInt("CatChoice", 2); 

            setCat(2);
        }
    }

    public void chooseSoniaBandana() {
        if (PlayerPrefs.GetInt("SBBought") == 0) {
            if (PlayerPrefs.GetInt("Coins") >= prices[3]) {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - prices[3]);
                PlayerPrefs.SetInt("SBBought", 1);
                PlayerPrefs.SetInt("CatChoice", 3);

                setCat(3);
            }
        }
        else {
            PlayerPrefs.SetInt("CatChoice", 3);

            setCat(3);
        }
    }
}
