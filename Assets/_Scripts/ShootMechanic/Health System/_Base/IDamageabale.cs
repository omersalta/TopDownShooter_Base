namespace _Scripts.ShootMechanic.Health_System._Base
{
    public interface IDamageabale
    {
        void Heal(float amount);
        void ArmorUp(float amount);
        void GetDamage(float damageAmount, float armourPenRate);
        void GetDirectDamage(float amount);
        void OnCharacterDead();
    }
}