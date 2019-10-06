using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] int blood;
    [SerializeField] GameObject bloodFading;
    [SerializeField] float destroyTime;

    private void OnMouseUp()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            return;
        }
        else
        {
            var next = FindObjectOfType<Money>();

            next.Gold += blood;
            Destroy(gameObject);

            GameObject deathVfxObject = Instantiate(bloodFading, transform.position, Quaternion.identity);
            Destroy(deathVfxObject, destroyTime);
        }
    }
}

