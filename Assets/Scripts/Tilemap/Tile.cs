using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    TilesManager grid;
    private Material _color;      // Базовый цвет клетки
    private Vector2 _ancor;       // Якорь клетки в глобальный координатах
    private bool valcable;
    private bool solid;
    private bool kills;

    private SpriteRenderer _spriteRenderer;

    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ancor = transform.position;
        grid = GameObject.Find("TileManeger").GetComponent<TilesManager>();
    }

    public void Init(float x, float y, bool valc, bool sol, bool kill) { 
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ancor = new Vector2(x, y);
        valcable = valc;
        solid = sol;
        kills = kill;

        if (valcable)
            _spriteRenderer.color = Color.green;
        if (kills)
            _spriteRenderer.color = Color.red;
        if (solid)
            _spriteRenderer.color = Color.gray;  
    }

    void Update() {

    }
}