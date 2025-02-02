using UnityEngine;

public class Enemy : CombatEntity
{
    public GameObject explosion;

    protected override void Start()
    {
        base.Start();
        target = TowerController.instance;
    }

    public void Initialize(int waveNumber)
    {
        statistics.healthMax = Mathf.RoundToInt(statistics.healthMax * (1 + waveNumber * 0.15f));
        statistics.attackPower = Mathf.RoundToInt(statistics.attackPower * (1 + waveNumber * 0.1f));
        statistics.moveSpeed = Mathf.RoundToInt(statistics.moveSpeed * (1 + waveNumber * 0.02f));
    }

    protected override void Update()
    {
        if (target == null)
        {
            target = TowerController.instance;
        }
        transform.LookAt(target.transform);
        base.Update();
    }

    protected override void Die()
    {
        GameManager.instance.enemyKilled += 1;
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        TowerController.instance.AddEnergy(statistics.energy);
        base.Die();
    }
}
