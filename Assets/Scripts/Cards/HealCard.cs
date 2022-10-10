public class HealCard : Card
{
    protected override void Use()
    {
        var buff = new HealBuff {amount = buffSo.buff.amount, duration = buffSo.buff.duration};
        var buff2 = new HealBuff {amount = buffSo.buff.amount, duration = buffSo.buff.duration};
        Add(buff, buff2);
        Destroy(gameObject);
    }
}