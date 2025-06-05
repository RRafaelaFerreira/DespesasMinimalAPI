
public static class DespesasRepository
{
    public static List<Despesas>? Despesa { get; set; }
    public static Despesas? AcharPorId(int Id)
    {
        if (Despesa != null)
        {
            return Despesa.FirstOrDefault(d => d.Id == Id);
        }
        return null;
    }

    public static void CriarBanco()
    {
        if (Despesa == null)
        {
            Despesa = new List<Despesas>();

            Despesas d = new Despesas();
            d.Id = 1; d.Descricao = "Padaria ABC";
            d.Data = new DateTime(2025, 6, 1); d.Valor = 16.00;
            Despesa.Add(d);

            d.Id = 2; d.Descricao = "Loja de calçados";
            d.Data = new DateTime(2025, 6, 2); d.Valor = 160.00;
            Despesa.Add(d);

            d.Id = 3; d.Descricao = "fast-food XYZ";
            d.Data = new DateTime(2025, 6, 3); d.Valor = 50.00;
            Despesa.Add(d);

            d.Id = 4; d.Descricao = "Bombonzinho loja de doces";
            d.Data = new DateTime(2025, 6, 3); d.Valor = 10.00;
            Despesa.Add(d);

            d.Id = 5; d.Descricao = "Pedágio Rodovia WZY";
            d.Data = new DateTime(2025, 6, 5); d.Valor = 10.00;
            Despesa.Add(d);

        }
    }
    public static void Remover(Despesas despesas)
    {
        if (Despesa != null)
        {
            Despesa.Remove(despesas);
        }

    }
}