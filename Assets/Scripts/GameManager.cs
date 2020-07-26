using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Events
    public delegate void TurnPassed();
    public static event TurnPassed turnPassedEvent;
    #endregion
    [SerializeField]
    private int houseCount = 16;
    private int sMisCount = 4;

    [SerializeField]
    private GameObject housePrefab = null;
    [SerializeField]
    private GameObject sMisPrefab = null;

    public int currentTurn = 0;
    private float turnDuration = 0.5f;

    private List<GameObject> sMis = new List<GameObject>();
    public List<House> houses = new List<House>();

    public House GetRandomHouse()
    {
        int index = UnityEngine.Random.Range(0, houses.Count);

        return houses[index];
    }

    private void Start()
    {
        SpawnHouses();
        SpawnSMis();

        StartTurns();
    }

    private void StartTurns()
    {
        StartCoroutine(DoTurn());
    }

    private IEnumerator DoTurn()
    {
        currentTurn += 1;

        turnPassedEvent?.Invoke();

        yield return new WaitForSeconds(turnDuration);

        if (sMis.Count > 0)
            StartCoroutine(DoTurn());
    }

    private void SpawnSMis()
    {
        for (int i = 0; i < sMisCount; i++)
        {
            GameObject go = Instantiate(sMisPrefab);
            go.transform.position = new Vector2(i, 0.0f);

            go.GetComponent<sMis>().Init();

            sMis.Add(go);
        }
    }

    public void RemoveSMis(GameObject sMisGameObject)
    {
        sMis.Remove(sMisGameObject);
    }

    private void SpawnHouses()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < houseCount / 4; j++)
            {
                GameObject go = Instantiate(housePrefab);
                go.transform.position = new Vector2(i, j);

                houses.Add(go.GetComponent<House>());
            }
        }
    }
}
