using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject[] bullets;
    private Animator anim;
    private PlayerController playerController;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerController.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        GameObject bullet = GetInactiveBullet();
        if (bullet != null)
        {
            bullet.transform.position = bulletPoint.position;
            bullet.GetComponent<Projectile>().SetDirection(transform.localScale.x); // Mermi yönünü ayarla
            bullet.SetActive(true); // Mermiyi aktif et
        }
    }

    private GameObject GetInactiveBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }
        return null;
    }
}
