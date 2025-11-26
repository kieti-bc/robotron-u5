using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
	RedRobot,
	BlueRobot
}

[System.Serializable]
public struct EnemyAmount
{
	public EnemyType type;
	public int amount;
}

[CreateAssetMenu(menuName="LevelData")]
public class LevelData : ScriptableObject {

	public int levelNumber;
	[SerializeField]
	public EnemyAmount[] enemyAmounts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
