namespace TG.ConceptApp.Application.QueryModel.Entities
{
    public class ReadonlyConcept
    {
        public int Id { get; set; }

        public string Super { get; set; }

        public string Sub { get; set; }

        public ReadonlyConcept(int id, string super, string sub)
        {
            Id = id;
            Super = super;
            Sub = sub;
        }

        public override string ToString()
            => $"[Id] {Id}\t[Super] {Super}\t[Sub] {Sub}";
    }
}
