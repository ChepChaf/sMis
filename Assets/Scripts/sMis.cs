using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMis : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float hunger = 0.0f;
    public float energy = 100.0f;
    public float social = 0.0f;

    public House house;

    Brain brain;

    public void Move(Transform targetPosition)
    {
        Vector3 direction = targetPosition.position - transform.position;

        transform.Translate(direction.normalized * 0.75f);
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        brain = new Brain(this);
    }

    public void Init()
    {
        hunger = Random.Range(0, 40);
        energy = Random.Range(40, 100);
    }

    private void DoTurn()
    {
        brain.Act();
    }

    private void OnEnable()
    {
        GameManager.turnPassedEvent += DoTurn;
    }

    private void OnDisable()
    {
        GameManager.turnPassedEvent -= DoTurn;
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.material.color = color;
    }
}
