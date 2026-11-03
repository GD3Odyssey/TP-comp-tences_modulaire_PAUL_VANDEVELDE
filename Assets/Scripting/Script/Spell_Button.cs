using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using DG.Tweening;

public class Spell_Button : MonoBehaviour
{
    [SerializeField] private Data_Spell spellData;

    [SerializeField] private TMP_Text spellNameText;
    [SerializeField] private TMP_Text spellDescriptionText;
    [SerializeField] private float spellCooldown;
    [SerializeField] private Image spellCooldownImage;
    [SerializeField] private Image IconImage;
    [SerializeField] private GameObject PlayerPrefab;
    

    bool isOnCooldown = false;


    public void Initialize(Data_Spell spell)
    {
        PlayerPrefab = GameObject.FindGameObjectWithTag("Tag_Player");
        spellData = spell;
        spellNameText.text = spellData._spellName;
        spellDescriptionText.text = spellData._spellDescription;
        spellCooldown = spellData._spellCooldown;
        IconImage.sprite = spellData._spellIcon;
    }

    public void Hover()
    {
        spellDescriptionText.transform.gameObject.SetActive(true);
    }
    public void ExitHover()
    {
        spellDescriptionText.transform.gameObject.SetActive(false);
    }
    public void OnMouseDown()
    {
        if (!isOnCooldown)
        {
            isOnCooldown = true;
            StartCoroutine(CooldownCoroutine());
            CastSpell();
        }
    }

    public void CastSpell()
    {
        GameObject projectile = Instantiate(spellData._ProjectilePrefab, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
        projectile.GetComponent<Bullet>().spellImpactPrefab = spellData._SpellImpactPrefab;
        Vector3 directionRegard = PlayerPrefab.transform.forward;
        float distanceTotale = spellData._projectileSpeed * spellData._spellLifetime;
        Vector3 targetPosition = projectile.transform.position + (directionRegard * distanceTotale);
        
        projectile.transform.DOMove(targetPosition, spellData._spellLifetime).SetEase(Ease.Linear).SetLink(projectile);
    }

    IEnumerator CooldownCoroutine()
    {
        float elapsedTime = 0f;
        spellCooldownImage.fillAmount = 1f;

        while (elapsedTime < spellCooldown)
        {
            elapsedTime += Time.deltaTime;
            spellCooldownImage.fillAmount = 1f - (elapsedTime / spellCooldown);
            yield return null;
        }

        spellCooldownImage.fillAmount = 0f;
        isOnCooldown = false;
    }
}
