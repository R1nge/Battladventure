public class PoisonCard : Card
{
    protected override void Use()
    {
        var buff = new DamageBuff {amount = buffSo.buff.amount, duration = buffSo.buff.duration};
        var buff2 = new DamageBuff {amount = buffSo.buff.amount, duration = buffSo.buff.duration};
        Add(buff, buff2);
        Destroy(gameObject);
    }
}