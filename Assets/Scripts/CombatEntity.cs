using UnityEngine;

public class CombatEntity : MonoBehaviour
{
    public GameObject projectile;
    public Statistics statistics;
    public CombatEntity target;

    protected bool isAttacking = false;
    protected float attackPeriod = 0.0f;
    protected float regenPeriod = 0.0f;

    protected virtual void Start()
    {
        statistics.health = statistics.healthMax;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        RegenRoutine();
        MoveRoutine();
        AttackRoutine();
    }

    protected virtual void RegenRoutine()
    {
        if (regenPeriod >= 1)
        {
            RegenerateHealth();
        }
        regenPeriod += Time.deltaTime;
    }

    public virtual void MoveRoutine()
    {
        if (statistics.moveSpeed > 0 && target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > statistics.attackRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, statistics.moveSpeed * Time.deltaTime);
            }
        }
    }

    protected virtual void AttackRoutine()
    {
        if (target != null)
        {
            bool canAttack = !isAttacking || attackPeriod >= 1 / statistics.attackSpeed;
            if (canAttack)
            {
                bool atRange = Vector3.Distance(transform.position, target.transform.position) <= statistics.attackRange;
                if (atRange)
                {

                    isAttacking = true;
                    if (statistics.projectileNumber >= 1)
                    {
                        Shoot(target);
                    }
                    else
                    {
                        Attack(target);
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

    protected virtual void Attack(CombatEntity target)
    {
        attackPeriod = 0;
        target.TakeDamage(ComputeAttackPower());
    }

    protected virtual void Shoot(CombatEntity target)
    {
        attackPeriod = 0;
        GameObject projectileGO = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileGO.GetComponent<Projectile>().Initialize(target, statistics.projectileSpeed, ComputeAttackPower());
    }

    protected virtual float ComputeAttackPower()
    {
        float damage = statistics.attackPower;
        bool isCritical = Random.value <= statistics.critChance; // Random.value retourne un float entre 0 et 1
        if (isCritical)
        {
            damage *= 1 + statistics.critMultiplier;
        }

        return Mathf.Round(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        bool isBlocked = Random.value <= statistics.blockChance;
        if (isBlocked)
        {
            return;
        }

        float reducedDamage = Mathf.Max(damage - statistics.defense, 0);
        statistics.health -= reducedDamage;

        if (statistics.health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void RegenerateHealth()
    {
        regenPeriod = 0;
        if (statistics.health < statistics.healthMax)
        {
            statistics.health = Mathf.Min(statistics.health + statistics.regen, statistics.healthMax);
        }
    }
}
