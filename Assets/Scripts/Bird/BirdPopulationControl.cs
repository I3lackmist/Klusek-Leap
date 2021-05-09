using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPopulationControl : MonoBehaviour {
    void Start() {
        StartCoroutine(controlBirdPopulation());
    }
    IEnumerator controlBirdPopulation() {
        while (true) {
            GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird");
            if (birds.Length > 1) {
                int index = 1;
                foreach (GameObject bird in birds) {
                    if (index > 2) {
                        Destroy(bird);
                    }
                    index++;
                }
            }
            yield return new WaitForSecondsRealtime(.5f);
        }
    }
}
