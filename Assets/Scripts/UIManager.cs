using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthLabel;
    public TextMeshProUGUI attackPower;
    public TextMeshProUGUI level;
    public TextMeshProUGUI enemyKilled;
    public TextMeshProUGUI stats;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthLabel.text = "HP  " + TowerController.instance.statistics.health + "/" + TowerController.instance.statistics.healthMax;
        healthBar.maxValue = TowerController.instance.statistics.healthMax;
        healthBar.value = TowerController.instance.statistics.health;
        attackPower.text = "" + TowerController.instance.statistics.attackPower;
        enemyKilled.text = "" + GameManager.instance.enemyKilled;
        level.text = "" + EnemySpawner.instance.waveNumber;

        stats.text = "" + TowerController.instance.statistics.ToString();
    }
}
