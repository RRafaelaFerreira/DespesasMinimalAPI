
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

    public static Despesas? AcharPorValor(double Valor){
        if (Despesa != null) {
            return Despesa.FirstOrDefault(d => d.Valor == Valor);
        }
        return null; 
    }

    public static void CriarBanco()
    {
        if (Despesa == null)
        {
            Despesa = new List<Despesas>();

            Despesa.Add(new Despesas
            {
                Id = 1,
                Descricao = "Padaria ABC",
                Data = new DateTime(2025, 6, 1),
                Valor = 16.00
            });

            Despesa.Add(new Despesas
            {
                Id = 2,
                Descricao = "Loja de calçados",
                Data = new DateTime(2025, 6, 2),
                Valor = 160.00
            });

            Despesa.Add(new Despesas
            {
                Id = 3,
                Descricao = "fast-food XYZ",
                Data = new DateTime(2025, 6, 3),
                Valor = 50.00
            });

            Despesa.Add(new Despesas
            {
                Id = 4,
                Descricao = "Bombonzinho loja de doces",
                Data = new DateTime(2025, 6, 3),
                Valor = 10.00
            });

            Despesa.Add(new Despesas
            {
                Id = 5,
                Descricao = "Pedágio Rodovia WZY",
                Data = new DateTime(2025, 6, 5),
                Valor = 10.00
            });
        }
    }
}