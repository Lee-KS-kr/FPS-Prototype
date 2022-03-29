using UnityEngine;

public class DestructibleBarrel : InteractionObjects
{
    [Header("Destructible Barrel")] [SerializeField]
    private GameObject destructibleBarrelPieces;

    private bool isDestroyed = false;

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            Instantiate(destructibleBarrelPieces, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
