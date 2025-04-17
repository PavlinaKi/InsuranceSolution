namespace InsuranceSolution.Application.Models.Email
{
    public class Email
    {
        public From from { get; set; }
        public To[] to { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string html { get; set; }
        public Personalization[] personalization { get; set; }
    }

    public class From
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class To
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class Personalization
    {
        public string email { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string company { get; set; }
    }

}
