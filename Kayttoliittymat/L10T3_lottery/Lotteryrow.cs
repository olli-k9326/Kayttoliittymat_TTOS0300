using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10T3_lottery
{
    class LotteryRow
    {
        private string gameType;
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
        public LotteryRow(string game)
        {
            DefineGame(game);
        }
        public void DefineGame(string game)
        {
            int numbersInRow = 3;
            gameType = game;
            switch (game)
            {
                case "Lotto":
                    Min = 1;
                    Max = 39;
                    numbersInRow = 7;
                    break;
                case "Viking Lotto":
                    Min = 1;
                    Max = 48;
                    numbersInRow = 6;
                    break;
                case "Eurojackpot":
                    Min = 1;
                    Max = 50;
                    numbersInRow = 7;
                    break;
            }
            row = new int[numbersInRow];
        }

        public void Randomize(Random r)
        {
            int newRandom;
            int[] temp1 = new int[5];
            int[] temp2 = new int[2];

            if (gameType == "Eurojackpot")
            {
                for (int i = 0; i < 5; i++)
                {
                    do
                    {
                        newRandom = r.Next(Min, Max + 1);
                    } while (temp1.Contains(newRandom));
                    temp1[i] = newRandom;
                }
                Array.Sort(temp1);
                for (int i = 0; i < 2; i++)
                {
                    do
                    {
                        newRandom = r.Next(1, 10);
                    } while (temp2.Contains(newRandom));
                    temp2[i] = newRandom;
                }
                Array.Sort(temp2);
                Array.Copy(temp1, 0, row, 0, 5);
                Array.Copy(temp2, 0, row, 5, 2);
            }
            else
            {
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

            
        }

        public override string ToString()
        {
            string s ="";
            for (int i = 0; i < row.Length; i++)
            {

                s += row[i];
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
        public void AddRandomRows(int N, string game)
        {
            Random r = new Random();

            for (int i = 0; i < N; i++)
            {
                LotteryRow newRandom = new LotteryRow(game);
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
            int i = 1;
            foreach(LotteryRow row in rows)
            {
                s += i + ")  " + row.ToString() + "\n";
                i++;
            }
            return s;
        }

    }
}
