using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BookBar : MonoBehaviour
{   [SerializeField] Slider slider;
    int max_score = 10;

    public void Start(){
        slider.maxValue = max_score;
        slider.value = 0;
    }

   public void SetScore(int Score){
       slider.value = Score;
   }
}
