using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour
{
    [SerializeField] Renderer _rend;

    void OnEnable()
    {
        Troop.DamageUnit += UpdateHealthBar;
    }

    void OnDisable()
    {
        Troop.DamageUnit -= UpdateHealthBar;
    }

    // Update is called once per frame
    void Update()
    {
        _rend.transform.rotation = Camera.main.transform.rotation;
    }

    void UpdateHealthBar(float healthValue)
    {
        _rend.material.SetFloat("_Health", healthValue);
    }
}
