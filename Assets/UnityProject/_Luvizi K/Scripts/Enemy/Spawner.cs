using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawner : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int totalToSpawn = 1000;
    [SerializeField] private int maxAlive = 100;
    [SerializeField] private float range = 1000f;
    [Header("Spawn overlap check (2D)")]
    [SerializeField] private float spawnCheckRadius = 0.5f;
    [SerializeField] private LayerMask spawnCollisionMask = Physics2D.DefaultRaycastLayers;
    [SerializeField] private int maxSpawnPositionAttempts = 30;
    private int spawnedCount = 0;
    [SerializeField] private int killedCount = 0;
    private int RemainingEnemies => Mathf.Max(0, totalToSpawn - killedCount);
    [Header("UI")]
    [SerializeField] private TMP_Text killedText;
    private bool isSpawningComplete = false;
    private HashSet<int> aliveEnemies = new HashSet<int>();
    private const string RemainingKey = "RemainingEnemies";
    private const string SpawnedKey = "SpawnedEnemies";
    private const string KilledKey = "KilledEnemies";
    private void SaveProgress()
    {
        PlayerPrefs.SetInt(KilledKey, killedCount);
        PlayerPrefs.Save();
    }
    private void LoadProgress()
    {
        killedCount = PlayerPrefs.GetInt(KilledKey, 0);
    }
    void Start()
    {
        LoadProgress();
        UpdateKilledText();
        int firstSpawn = Mathf.Min(maxAlive, RemainingEnemies);
        for (int i = 0; i < firstSpawn; i++)
            SpawnEnemy();
        if (spawnedCount >= totalToSpawn)
            isSpawningComplete = true;
    }
    private void SpawnEnemy()
    {
        if (spawnedCount >= totalToSpawn)
        {
            isSpawningComplete = true;
            return;
        }
        Vector2 spawnPos;
        if (!TryGetSpawnPosition(out spawnPos))
        {
            spawnPos = new Vector2(
                UnityEngine.Random.Range(-range / 2f, range / 2f),
                UnityEngine.Random.Range(-range / 2f, range / 2f)
            );
        }
        GameObject enemy = Instantiate(enemyPrefab, (Vector3)spawnPos, Quaternion.identity);
        int id = enemy.GetInstanceID();
        aliveEnemies.Add(id);
        spawnedCount++;
        EnemyBase enemyScript = enemy.GetComponent<EnemyBase>();
        if (enemyScript != null)
        {
            Action handler = null;
            handler = () =>
            {
                OnEnemyDiedInternal(id);
                enemyScript.OnEnemyDeath -= handler;
            };
            enemyScript.OnEnemyDeath += handler;
        }
        else
        {
            var notifier = enemy.AddComponent<SpawnerEnemyNotifier>();
            notifier.Init(this, id);
        }
        if (spawnedCount >= totalToSpawn)
            isSpawningComplete = true;
    }
    private bool TryGetSpawnPosition(out Vector2 result)
    {
        for (int i = 0; i < maxSpawnPositionAttempts; i++)
        {
            float x = UnityEngine.Random.Range(-range / 2f, range / 2f);
            float y = UnityEngine.Random.Range(-range / 2f, range / 2f);
            Vector2 pos = new Vector2(x, y);
            Collider2D hit = Physics2D.OverlapCircle(pos, spawnCheckRadius, spawnCollisionMask);
            if (hit == null)
            {
                result = pos;
                return true;
            }
        }
        result = Vector2.zero;
        return false;
    }
    private void OnEnemyDiedInternal(int id)
    {
        if (!aliveEnemies.Remove(id)) return;
        killedCount = Mathf.Min(totalToSpawn, killedCount + 1);
        UpdateKilledText();
        SaveProgress();
        if (!isSpawningComplete && spawnedCount < totalToSpawn && aliveEnemies.Count < maxAlive)
        {
            SpawnEnemy();
        }
        if (RemainingEnemies <= 0 && aliveEnemies.Count == 0)
        {
            Debug.Log("All enemies defeated! You win!");
            PlayerPrefs.DeleteKey(KilledKey);
            PlayerPrefs.Save();
            //WinGameScript.Instance?.WinGame();
        }
    }
    private void UpdateKilledText()
    {
        if (killedText != null)
        {
            killedText.text = $"Alive: {RemainingEnemies}";
        }
    }
    public void NotifyEnemyDeath(int id) => OnEnemyDiedInternal(id);
}
public class SpawnerEnemyNotifier : MonoBehaviour
{
    private Spawner spawner;
    private int id;
    private EnemyBase enemyBase;
    public void Init(Spawner spawner, int id)
    {
        this.spawner = spawner;
        this.id = id;
        enemyBase = GetComponent<EnemyBase>();
        if (enemyBase != null)
            enemyBase.OnEnemyDeath += OnEnemyDeathInternal;
    }
    private void OnEnemyDeathInternal()
    {
        NotifyAndCleanup();
    }
    private void OnDestroy()
    {
        NotifyAndCleanup();
    }
    private void NotifyAndCleanup()
    {
        if (spawner != null)
        {
            spawner.NotifyEnemyDeath(id);
            spawner = null;
        }
        if (enemyBase != null)
            enemyBase.OnEnemyDeath -= OnEnemyDeathInternal;
    }
}