using System.Collections.Generic;
using UnityEngine;

public sealed class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int count = 5;

    private readonly List<Health> alive = new();
    
    public bool IsCleared => alive.Count == 0;

    public void Spawn()
    {
        ClearTracking();

        for (int i = 0; i < count; i++)
        {
            Transform sp = spawnPoints[i % spawnPoints.Length];
            GameObject go = Instantiate(enemyPrefab, sp.position, sp.rotation);

            var chaser = go.GetComponent<EnemyChaser>();
            if (chaser != null && player != null)
            {
                chaser.SetTarget(player);
            }

            Health hp = go.GetComponent<Health>();
            if (hp != null)
            {
                alive.Add(hp);
                hp.Died += OnEnemyDied;
            }

            var shooter = go.GetComponent<EnemyShooter>();
            if (shooter != null && player != null)
            {
                shooter.SetTarget(player);
            }
        }
    }

    private void OnEnemyDied(Health hp)
    {
        hp.Died -= OnEnemyDied;
        alive.Remove(hp);
    }

    private void ClearTracking()
    {
        for (int i = alive.Count - 1; i >= 0; i--)
        {
            if (alive[i] != null) alive[i].Died -= OnEnemyDied;
        }
        alive.Clear();
    }
}
