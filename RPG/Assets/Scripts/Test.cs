using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public Enemy Enemy { get; private set;}
    public Player Player { get; private set; }

    private void Awake()
    {
        var enemyCreator = new EnemyCreator();
        var playerCreator = new PlayerCreator();
        Enemy = enemyCreator.CreateEnemy(gameObject);
        Player = playerCreator.CreatePlayer(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Player.CastSpell(Enemy, 0);
            ShowInfo();
        }   
    }

    private void ShowInfo()
    {
        Debug.Log("EnemyStatus:  ");
        Enemy.Print();
        Debug.Log("PlayerStatus:  ");
        Player.Print();
    }


}
