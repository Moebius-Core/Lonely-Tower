using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public GameObject[] enemyPrefabs; // Liste des types d’ennemis (faible, moyen, fort)
    public GameObject bossPrefab; // Boss
    public TowerController target; // La tour à attaquer
    public float spawnRadius = 10f; // Rayon autour duquel les ennemis apparaissent
    public float spawnInterval = 1.2f; // Temps entre chaque spawn


    [Header("Paramètres des vagues")]
    public int waveNumber = 0; // Numéro de la vague actuelle

    private void Start()
    {
        instance = this;
        StartNextWave();
    }

    public void StartNextWave()
    {
        waveNumber++;
        StartCoroutine(SpawnWave(waveNumber));
    }

    IEnumerator SpawnWave(int wave)
    {
        int totalEnemies = Mathf.RoundToInt(10 + wave * 1.5f); // Nombre total d'ennemis dans la vague
        int groupSize = Mathf.Max(2, totalEnemies / 4); // Taille des paquets (min 2)

        int spawnedEnemies = 0;
        while (spawnedEnemies < totalEnemies)
        {
            int currentGroupSize = Mathf.Min(groupSize, totalEnemies - spawnedEnemies); // Dernier groupe ajusté si besoin

            // Spawn d’un groupe entier
            for (int i = 0; i < currentGroupSize; i++)
            {
                SpawnEnemy();
            }

            spawnedEnemies += currentGroupSize;

            // Pause entre chaque groupe (réduit légèrement avec le temps)
            float delay = Mathf.Max(spawnInterval - wave * 0.05f + Random.Range(-0.2f, 0.2f), 0.1f);
            yield return new WaitForSeconds(delay);
        }

        if (wave % 10 == 0) // Toutes les 10 vagues, un boss
        {
            SpawnBoss();
            yield return new WaitForSeconds(10);
        }
        StartNextWave();
    }

    void SpawnEnemy()
    {
        Vector2 randomPos = Random.insideUnitCircle.normalized * (spawnRadius + Random.Range(-1, 3)); // Position al�atoire autour du centre
        Vector3 spawnPosition = new Vector3(randomPos.x, 0, randomPos.y) + transform.position;

        int enemyIndex = GetEnemyIndex(); // Choix de l’ennemi selon la vague
        GameObject enemyGO = Instantiate(enemyPrefabs[enemyIndex], spawnPosition, Quaternion.identity);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Initialize(waveNumber);
    }

    void SpawnBoss()
    {
        Vector2 randomPos = Random.insideUnitCircle.normalized * spawnRadius; // Position al�atoire autour du centre
        Vector3 spawnPosition = new Vector3(randomPos.x, 0, randomPos.y) + transform.position;

        GameObject bossGO = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        Enemy boss = bossGO.GetComponent<Enemy>();

        // Boost massif des stats du boss
        boss.Initialize(waveNumber);
        boss.transform.localScale *= 1.5f; // Augmente la taille du boss
    }

    int GetEnemyIndex()
    {
        if (waveNumber < 3) return 0; // Seulement les ennemis faibles au début
        if (waveNumber < 6) return Random.Range(0, 2); // Mélange faible et moyen
        return Random.Range(0, enemyPrefabs.Length); // Ajoute les ennemis forts
    }
}
