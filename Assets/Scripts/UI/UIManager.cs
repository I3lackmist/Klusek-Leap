using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    [SerializeField] GameObject mutebtn,skins_button, exit_store_button, exit_skins_button, store_button, score, combo, skin_store, mouse_img, highscore, tuttext, store_store;
    bool uiclosed;

    private void Start() {
        uiclosed = false;
    }
    public void CloseUI() {
        mutebtn.SetActive(false);
        tuttext.SetActive(false);
        skins_button.SetActive(false);
        store_store.SetActive(false);
        store_button.SetActive(false);
        score.SetActive(true);
        combo.SetActive(true);
        skin_store.SetActive(false);
        mouse_img.SetActive(false);
        highscore.SetActive(false);
        uiclosed = true;
    }

    public void openSkinMenu() {
        mutebtn.SetActive(false);
        tuttext.SetActive(false);
        highscore.SetActive(false);
        store_store.SetActive(false);
        store_button.SetActive(false);
        exit_skins_button.SetActive(true);
        skins_button.SetActive(false);
        skin_store.SetActive(true);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>().enabled = false;
    }

    public void openStoreMenu() {
        mutebtn.SetActive(false);
        tuttext.SetActive(false);
        exit_store_button.SetActive(true);
        store_store.SetActive(true);
        highscore.SetActive(false);
        skins_button.SetActive(false);
        store_button.SetActive(false);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>().enabled = false;
    }

    public void CloseSkinMenu() {
        mutebtn.SetActive(true);
        tuttext.SetActive(true);
        highscore.SetActive(true);
        skin_store.SetActive(false);
        exit_skins_button.SetActive(false);
        skins_button.SetActive(true);
        store_button.SetActive(true);
        store_store.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>().enabled = true;
    }

    public void CloseStoreMenu() {
        tuttext.SetActive(true);
        mutebtn.SetActive(true);
        highscore.SetActive(true);
        skin_store.SetActive(false);
        exit_store_button.SetActive(false);
        skins_button.SetActive(true);
        store_store.SetActive(false);
        store_button.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>().enabled = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!uiclosed && !store_store.activeSelf && !skin_store.activeSelf) {
                Application.Quit();
            }
            else if (uiclosed) {
                SceneManager.LoadScene("Menu");
            }
            else if (store_store.activeSelf) {
                CloseStoreMenu();
            }
            else if (skin_store.activeSelf) {
                CloseSkinMenu();
            }
            
        }
    }
}
