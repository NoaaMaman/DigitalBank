namespace LINQLawyer
{
    public class Case
    {
        public Client client { get; set; } = default!;

        public Lawyer lawyer { get; set; } = default!;

        public string Title { get; set; } = default!;

        public CaseType CaseType { get; set; } = default!;

        public decimal AmountInDispute { get; set; } = default!;




    }

    public enum CaseType 
    {
        Commercial,
        ProBono
    }
}