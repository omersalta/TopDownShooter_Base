namespace _Scripts.ShootMechanic.Health_System._Base
{
    public interface IDamageabale
    {
        void Damage(float damageAmount, float armourPenRate);
        void DirectDamage(float amount);
        Team GetTeam();
        float Health(); 
        float Armor();
    }
}