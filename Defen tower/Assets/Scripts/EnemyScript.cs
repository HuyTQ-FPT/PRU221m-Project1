
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private Transform canvas;
    private Slider healthBar;
    private float health;

    private void OnEnable()
    {
        canvas = transform.Find("Canvas");
        healthBar = canvas.Find("HealthBar").GetComponent<Slider>();
        canvas.gameObject.SetActive(false);

        healthBar.value = health;
    }

    private void Update()
    {
        canvas.rotation = Quaternion.identity;
        canvas.localScale = Vector3.one * 0.5f;
    }


}
