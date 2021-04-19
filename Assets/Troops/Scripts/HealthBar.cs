using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Renderer _rend;

    // Update is called once per frame
    void Update()
    {
        _rend.transform.rotation = Camera.main.transform.rotation;
    }

    public void UpdateHealthBar(float healthValue)
    {
        _rend.material.SetFloat("_Health", healthValue);
    }
}
