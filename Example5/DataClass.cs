using System.Collections.Generic;

namespace Example5
{
    class DataClass
    {
        public List<string> names = new List<string>();
        public DataClass(string name)
        {
            for(int i = 0; i < 500; i++)
            {
                names.Add(name + " #" + i.ToString());
            }
        }
    }
}
