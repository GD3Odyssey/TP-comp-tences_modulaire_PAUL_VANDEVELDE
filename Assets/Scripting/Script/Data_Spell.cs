using UnityEngine;

[CreateAssetMenu(fileName = "Data_Spell", menuName = "Scriptable Objects/Data_Spell")]
public class Data_Spell : ScriptableObject
{
    [Header("Spell Info")]
    public string _spellName;
    public string _spellDescription;
    public Sprite _spellIcon;

    [Header("Spell Stats")]
    public float _spellDamage;
    public float _spellCooldown;
    public float _spellLifetime;

    [Header("Projectile")]
    public GameObject _ProjectilePrefab;
    public float _projectileSpeed;
    
    [Header("Style")]
    public GameObject _SpellImpactPrefab;
    public Animator _AnimationTrigger;

}
