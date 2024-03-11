using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Book
    {
        public int id;
        public string kateg;
        public string cim;
        public int ar;
        public int db;

        public Book(string id, string kateg, string cim, string ar, string db)
        {
            this.id = int.Parse(id);
            this.kateg = kateg;
            this.cim = cim;
            this.ar = int.Parse(ar);
            this.db = int.Parse(db);
        }
    }
}
