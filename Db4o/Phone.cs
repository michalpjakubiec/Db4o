using System.Collections.Generic;

namespace Nbd_Db4o
{
    public class Phone : List<Phone>
    {
        public string Number { get; set; }
        public string OperatorName { get; set; }
        public string Type { get; set; }
        public Person Person { get; set; }

        public Phone() { }
        public Phone(string number, string operatorName, string type)
        {
            Number = number;
            OperatorName = operatorName;
            Type = type;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Number, Type, OperatorName);
        }
    }
}
