using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(GameObject))]

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointParent;
    [SerializeField] private GameObject _enemy;

    private System.Random _random = new System.Random();
    private int _randomMin = 0;
    private int _randomMax;
    private Transform[] _spawnPoints;
    private float _interval = 2;
    private bool _spawnIsNeeded = true;

    private void Start()
    {
        _spawnPoints = _spawnPointParent.GetComponentsInChildren<Transform>();
        _randomMax = _spawnPoints.Length - 1;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_spawnIsNeeded)
        {
            int randomIndex = _random.Next(_randomMin, _randomMax);
            Instantiate(_enemy, _spawnPoints[randomIndex]);

            yield return new WaitForSeconds(_interval);
        }
    }
}
