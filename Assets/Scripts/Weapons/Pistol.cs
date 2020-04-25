using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);
    }
}
