using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject BulletPrototype;
    public float ShootingPeriod;
    public float Range;
    public float BulletSpeed;
    public float Damage;
    public float RotationSpeed;
    public List<GameObject> Enemies;

    private GameObject bulletPlaceholder;
    private float timeToShoot = 0.0f;
    private List<string> enemyTags;

	void Start ()
	{
	    enemyTags = Enemies.Select(e => e.tag).ToList();
        var enemy = EnemyManagerScript.Instance.GetEnemyInRange(transform.position, float.PositiveInfinity, enemyTags);

	    bulletPlaceholder = transform.Find("Rocket").gameObject;
	}

    void FixedUpdate ()
    {
        var enemy = EnemyManagerScript.Instance.GetEnemyInRange(transform.position, Range, enemyTags);

        if (enemy != null)
        {
            TurnToEnemy(enemy.transform.position + enemy.transform.right * 32);

            if (timeToShoot < 0)
            {
                
            }
        }
        else
        {
            var closestEnemy = EnemyManagerScript.Instance.GetClosestEnemyInRange(transform.position, Range*2, enemyTags);
            if (closestEnemy != null) TurnToEnemy(closestEnemy.transform.position + closestEnemy.transform.right * 32);
        }

        if (bulletPlaceholder != null && timeToShoot < ShootingPeriod / 8.0f && !bulletPlaceholder.activeSelf)
        {
            bulletPlaceholder.SetActive(true);
        }

        timeToShoot -= Time.deltaTime;
    }

    private void TurnToEnemy(Vector2 position)
    {
        var direction = position - (Vector2)transform.position;
        transform.Rotate(0, 0, Mathf.Clamp(10, -10, 10) * RotationSpeed * Time.deltaTime);
    }
}
