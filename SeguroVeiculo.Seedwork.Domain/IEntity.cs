namespace SeguroVeiculo.Seedwork.Domain
{
    public interface IEntity
    {
        bool IsTransient();
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}