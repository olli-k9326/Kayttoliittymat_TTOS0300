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
        private int starMin;
        private int starMax;
        private int[] star;
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
            try
            {
                int numbersInRow = 3;
                gameType = game;
                switch (game)
                {
                    case "Lotto":
                        Min = 1;
                        Max = 39;
                        numbersInRow = 7;
                        star = null;
                        break;

                    case "Viking Lotto":
                        Min = 1;
                        Max = 48;
                        numbersInRow = 6;
                        star = null;
                        break;

                    case "Eurojackpot":
                        Min = 1;
                        Max = 50;
                        starMin = 1;
                        starMax = 10;
                        numbersInRow = 5;
                        star = new int[2];
                        break;
                }
                row = new int[numbersInRow];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Randomize(Random r)
        {
            try
            {
                int newRandom;

                if (gameType == "Eurojackpot")
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
                    for (int i = 0; i < star.Length; i++)
                    {
                        do
                        {
                            newRandom = r.Next(starMin, starMax + 1);
                        } while (star.Contains(newRandom));
                        star[i] = newRandom;
                    }
                    Array.Sort(star);
                }
                else
                {
                    for (int i = 0; i < this.row.Length; i++)
                    {
                        do
                        {
                            newRandom = r.Next(Min, Max + 1);
                        } while (this.row.Contains(newRandom));
                        this.row[i] = newRandom;
                    }
                    Array.Sort(this.row);
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public override string ToString()
        {
            try
            {
                string s = "";
                for (int i = 0; i < row.Length; i++)
                {

                    s += row[i];
                    if (i < row.Length - 1)
                    {
                        s += " ";
                    }

                }
                if (star != null)
                {
                    for (int i = 0; i < star.Length; i++)
                    {
                        s += " ";
                        s += star[i];
                    }
                }
                return s;
            }
            catch (Exception)
            {

                throw;
            }
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
            try
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
            catch (Exception)
            {

                throw;
            }
            
        }
        public void AddRandomRows(int N, string game)
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }

        public override string ToString()   
        {
            try
            {
                string s = "";
                int i = 1;
                foreach (LotteryRow row in rows)
                {
                    s += i + ")  " + row.ToString() + "\n";
                    i++;
                }
                return s;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
