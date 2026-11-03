using System.Collections.Generic;
using UnityEngine;


public class Spell_Manager : MonoBehaviour
{
    [SerializeField]
    private List<Data_Spell> spellList = new List<Data_Spell>();

    [SerializeField]
    private GameObject ButtonPrefab;

    void Awake()
    {
        ChargerLesScriptableObjects();
    }

    void ChargerLesScriptableObjects()
    {
        Data_Spell[] tousLesSpells = Resources.LoadAll<Data_Spell>("Spell");

        foreach (Data_Spell spell in tousLesSpells)
        {
            spellList.Add(spell);
            GameObject button = Instantiate(ButtonPrefab, transform);
            button.GetComponent<Spell_Button>().Initialize(spell);
        }
    }
}
