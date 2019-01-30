namespace KotProno2.Models
{
    public class Team
    {
        public Team(string name, string isoCode)
        {
            Name = name;
            IsoCode = isoCode;
        }

        public string Name { get; }
        public string IsoCode { get; }
    }
}