
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float MaxHealth;
    public int Money;
    public GameObject Coin;
    public float SpawnedCoinMean;
    public float SpawnedCoinStd;

    private Transform canvas;
    private Slider healthBar;
    private float health;

    private void OnEnable()
    {
        canvas = transform.Find("Canvas");
        healthBar = canvas.Find("HealthBar").GetComponent<Slider>();
        canvas.gameObject.SetActive(false);

        health = MaxHealth;
        healthBar.maxValue = MaxHealth;
        healthBar.value = health;
    }

    private void Update()
    {
        canvas.rotation = Quaternion.identity;
        canvas.localScale = Vector3.one * 0.5f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.activeSelf) return;

        if (collision.CompareTag("finish"))
        {

        }
        else if ((collision.CompareTag("bullet") && !CompareTag("plane")) || (collision.CompareTag("rocket") && !CompareTag("soldier")))
        {
        }
           
    }
}
