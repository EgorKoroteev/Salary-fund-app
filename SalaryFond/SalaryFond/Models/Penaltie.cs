namespace SalaryFond.Models
{
    internal class Penalties
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private int _Summ;

        public int Summ
        {
            get { return _Summ; }
            set { _Summ = value; }
        }

        public Penalties() { }
    }
}
