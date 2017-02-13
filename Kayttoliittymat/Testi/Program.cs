using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRow();
        }

        static void TestRow()
        {
            Random r = new Random();
            LotteryRows rows = new LotteryRows();
            rows.AddRandomRows(15, 7, 1, 39);
            Console.WriteLine(rows.ToString());
            /*
            LotteryRow row = new LotteryRow(6, 1, 39);
            row.Row = new int[]{ 1, 13, 38, 7, 26, 3 };
            LotteryRow row2 = new LotteryRow(6, 1, 39);
            row2.Row = new int[] {6, 9, 38, 7, 32, 3 };
            LotteryRow row3 = new LotteryRow(6, 1, 39);
            row3.Row = new int[] { 1, 32, 38, 12, 26, 1 , 5};
            LotteryRow row4 = new LotteryRow(6, 1, 39);
            row4.Row = new int[] { 3, 13, 38, 7, 26, 1 };
            

            for (int i = 0; i < 20; i++)
            {
                row2.Randomize(r);
                Console.WriteLine(row2.ToString());
            }
            */


            /*
            rows.Add(row);
            rows.Add(row2);
            rows.Add(row3);
            bool what1 = row4.row.SequenceEqual(row.row);

            Console.WriteLine(what1);

            Array.Sort(row.row);
            what1 = row4.row.SequenceEqual(row.row);
            Console.WriteLine(what1);

            Array.Sort(row4.row);
            what1 = row4.row.SequenceEqual(row.row);
            Console.WriteLine(what1);
            Console.WriteLine(row4.ToString());

            Console.WriteLine(rows.ToString());
            */
        }
    }
}
