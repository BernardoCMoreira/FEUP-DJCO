﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{   

    public IEnumerator Shake(float duration){
        Vector3 originalPos = transform.localPosition;
        
        float elapsed = 0.0f;
        while(elapsed < duration){
            float x = Random.Range(-1f, 1f) + originalPos.x;
            float y = Random.Range(-1f, 1f) + originalPos.y;
            
            transform.localPosition = new Vector3(x,y,originalPos.z);

            elapsed += Time.deltaTime;

            yield return null; /* yield for coroutine */
        }

        transform.localPosition = originalPos;
    }

}
