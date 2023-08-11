using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Slider slider;

    private EnemyState enemy;
    // Start is called before the first frame update

    void Start()
    {
        slider = GetComponent<Slider>();
        enemy = GetComponentInParent<EnemyState>();
        slider.maxValue = enemy.getMaxHP();
        slider.value = enemy.getHP();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemy.getHP();
    }
}
