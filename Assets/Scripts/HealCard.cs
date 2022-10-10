public class HealCard : Card
{
    protected override void Use()
    {
        var buff = new HealBuff {amount = buffSo.buff.amount, duration = buffSo.buff.duration};
        FindObjectOfType<Player>().buffs.Add(buff);
        Destroy(gameObject);
    }
}