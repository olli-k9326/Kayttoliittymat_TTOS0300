using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    class LotteryRow
    {
        private int[] row;
        public int[] Row
        {
            get { return row; }
            set {
                row = value;
                Array.Sort(row);
            }
        }
        public int Min { get; set; }
        public int Max { get; set; }

        public LotteryRow(int Size, int min, int max)
        {
            row = new int[Size];
            Min = min;
            Max = max;
        }

        public void Randomize(Random r)
        {
            int newRandom;
            for (int i = 0; i < row.Length; i++)
            {
                do
                {
                    newRandom = r.Next(Min, Max + 1);
                } while (row.Contains(newRandom));
                row[i] = newRandom;
            }
            Array.Sort(row);
        }

        public override string ToString()
        {
            string s ="";
            for (int i = 0; i < row.Length; i++)
            {
                s += string.Format("{0,2}", row[i]);
                if (i < row.Length -1)
                {
                    s += " ";
                } 

            }
            return s;
        }

    }
    class LotteryRows
    {
        private List<LotteryRow> rows;


        public List<LotteryRow> Rows
        {
            get { return rows; }
        }
        public LotteryRows()
        {
            rows = new List<LotteryRow>();
        }

        public void AddRandomRows(int N, int Size, int Min, int Max)
        {
            Random r = new Random();
            
            for (int i = 0; i < N; i++)
            {
                LotteryRow newRandom = new LotteryRow(Size, Min, Max);
                do
                {
                    newRandom.Randomize(r);
                } while (rows.Contains(newRandom));
                rows.Add(newRandom); 
            }
            
        }

        public override string ToString()   
        {
            string s ="";
            foreach(LotteryRow row in rows)
            {
                s += row.ToString() + "\n";
            }
            return s;
        }

    }
}
