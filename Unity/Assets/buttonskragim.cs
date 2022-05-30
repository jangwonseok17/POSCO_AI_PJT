using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonskragim : MonoBehaviour{
    // Start is called before the first frame update
    private bool state;

    void Start () {
            state = true;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("입력");
            if (state == true)
            {
                gameObject.SetActive(false);
                print("사라져");
                state = false;
            }

            else
            {
                gameObject.SetActive(true);
                print("생겨나");
                state = true;
            }
        }
    }
}