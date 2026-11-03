using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject spellImpactPrefab;
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Tag_Ennemi"))
        {
            gameObject.SetActive(false);
            if (spellImpactPrefab != null)
            {
                GameObject impact = Instantiate(spellImpactPrefab, transform.position, Quaternion.identity);
                Destroy(impact, 2f);
            }

            Destroy(gameObject);
        }
    }
}
