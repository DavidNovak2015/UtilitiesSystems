namespace VerzovaciSystem.Models.Entities
{
    // pro vyhledávací masku
    public class CompanyTypeEntity
    {
        public string Type { get; private set; }
        public string Description { get; private set; }

        public CompanyTypeEntity(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }
}