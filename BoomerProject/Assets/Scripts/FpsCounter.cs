using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{

    public float updateRate;
    public Text txt;

    int frames;
    float deltaTime;

    void Update()
    {
        frames++;
        deltaTime += Time.deltaTime;

        if (deltaTime > 1.0/updateRate)
        {
            TextUpdate();

            deltaTime -= 1.0f / updateRate;
            frames = 0;
        }
    }

    void TextUpdate()
    {
        txt.text = "" + Mathf.RoundToInt(frames / deltaTime);
    }
}
