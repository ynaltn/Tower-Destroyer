using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour,IDamageable
{
    [SerializeField]
    private float _respawnTime;
    [SerializeField]
    private GameObject _healthPanel;
    [SerializeField]
    private TMP_Text _healthText;
    [SerializeField]
    private RectTransform _healthBar;
    [SerializeField]
    private MeshRenderer _meshRenderer;

    EnemyAnimatorManager _enemyAnimatorManager;
    ShopUIController _shopUIController;
    int coinIncrease;

    private float _hpBarStartWidth;

    private bool _isDead;
   [field: SerializeField] public float _maxHealth { get; set; }
    public float _currentHealth { get; set; }
    
    private void Start()    
    {
       // coinIncrease = GetComponent<ShopUIController>().coinCount;
        _enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentHealth = _maxHealth;
        _hpBarStartWidth = _healthBar.sizeDelta.x;
        UpdateUI();
        
    }


    public void ApplyDamage(float dmg)
    {
        if (_isDead) return;
        _currentHealth -= dmg;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            _isDead = true;
            _meshRenderer.enabled = false;
            _healthPanel.SetActive(false);
            StartCoroutine(RespawnAfterTime());
        }
        UpdateUI();
    }
    

    IEnumerator RespawnAfterTime()
    {
        KillEnemy();
        yield return new WaitForSeconds(_respawnTime);
        //coinIncrease++;
        Destroy(gameObject);
    }

    void KillEnemy()
    {
        _enemyAnimatorManager.animator.SetBool("Die", true);
        
    }
    void UpdateUI()
    {
        float percentOutOf = (_currentHealth / _maxHealth) * 100;
        float newWidth = (percentOutOf / 100) * _hpBarStartWidth;

        _healthBar.sizeDelta = new Vector2(newWidth, _healthBar.sizeDelta.y);
        _healthText.text = _currentHealth + "/" + _maxHealth;
    }

}
