using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeInterval;
    [SerializeField] private GameObject _EnemyObject;
    private Transform[] _wayPoints;
    private int _wayPointsLenght;

    public void Start()
    {
        _wayPoints = GetComponentsInChildren<Transform>();
        _wayPointsLenght = _wayPoints.Length;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds interval = new WaitForSeconds(_timeInterval);
        for (int i = 1; true; i++)
        {
            if (i == _wayPointsLenght)
            {
                i = 1;
            }
            Instantiate(_EnemyObject, _wayPoints[i].position, Quaternion.identity);
            yield return interval;
        }
    }
}
