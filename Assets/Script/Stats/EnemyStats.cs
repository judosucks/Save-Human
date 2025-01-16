using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    private Player player;
    private ItemDrop myDropSystem;
    [Header("level details")]
    [SerializeField]private int level = 1;

    [Range(0f, 1f)] 
    [SerializeField] private float percentageModifier =0.4f;
    
    protected override void Start()
    {
        ApplyModifier();
        base.Start();
        enemy = GetComponent<Enemy>();
        player = PlayerManager.instance.player;
        myDropSystem = GetComponent<ItemDrop>();
    }

    private void ApplyModifier()
    {
        Modify(strength);
        Modify(agility);
        Modify(intelligence);
        Modify(vitality);
        
        Modify(damage);
        Modify(critChance);
        Modify(critPower);
        
        Modify(maxHealth);
        Modify(armor);
        Modify(evasion);
        Modify(magicResistance);
        
        Modify(fireDamage);
        Modify(iceDamage);
        Modify(lightningDamage);
    }

    public void Modify(Stat _stat)
    {
        for (int i = 1; i < level; i++)
        {
            float modifier = _stat.GetValue() * percentageModifier;
            _stat.AddModifier(Mathf.RoundToInt(modifier));
        }
    }
    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
       
    }

    protected override void Die()
    {
        base.Die();
        myDropSystem.GenerateDrop();
        enemy.Die();
        Destroy(gameObject,.5f);
    }
}
