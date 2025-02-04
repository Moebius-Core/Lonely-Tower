using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerController : CombatEntity
{
    public static TowerController instance;

    protected override void Start()
    {
        base.Start();
        instance = this;
    }

    protected override void Die()
    {
        // GAME OVER
        SceneManager.LoadScene("MainMenuScene");
        instance = null;
        base.Die();
    }

    protected override void AttackRoutine()
    {
        List<Enemy> enemiesInRange = FindEnemiesInRange();

        if (enemiesInRange.Count > 0)
        {
            
            bool canAttack = !isAttacking || attackPeriod >= 1 / statistics.attackSpeed;
            if (canAttack)
            {
                isAttacking = true;
                for (int i = 0; i < statistics.projectileNumber; i++)
                {
                    if (i < enemiesInRange.Count)
                    {
                        Shoot(enemiesInRange[i]);
                    }
                }
            }
        }
        else
        {
            isAttacking = false;
        }
        attackPeriod += Time.deltaTime;
    }

    private List<Enemy> FindEnemiesInRange()
    {
        return FindObjectsByType<Enemy>(FindObjectsSortMode.None) // Récupère tous les ennemis
            .Where(enemy => Vector3.Distance(transform.position, enemy.transform.position) <= statistics.attackRange) // Filtre ceux à portée
            .OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)) // Trie par distance croissante
            .ToList();
    }

    public void AddEnergy(float value)
    {
        statistics.energy += (int)value;
    }

    public void ApplyUpgrade(TowerUpgradeSO upgrade)
    {
        if (statistics.energy >= -upgrade.statistics.energy)
        {
            statistics += upgrade.statistics;
        }
    }
}
