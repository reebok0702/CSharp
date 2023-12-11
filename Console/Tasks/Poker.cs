using System;

namespace Poker
{
    internal class Program
    {
        static char[][] strarr = new char[2][];
        static byte[] SortCount = new byte[5];
        static char[,] carr = new char[2, 5];
		static string skarti;

        static void SortStr(string str)
        {
            bool b = true;
            byte i = 0, j = 0, btmp;
			
			
            
            foreach (char c in str)
            {
				
                if (c == ' ' || c == '0')
				{
					continue;
				}

                else if (b)  
                {
                    
                    carr[i, j] = c;
                    i++; b = false;
                }
                else 
                { 
                    carr[i, j] = c;
                    i--; b = true; j++;
                }
				
            }
            
            for(i = 0; i < 5; i++)
            {
                for(j = 0; j < 13; j++)
                {
                    if (carr[0,i] == strarr[0][j])
                    {
                        SortCount[i] = j; break;
                    }
                }
            }

            for (i = 0; i < 5; i++)
            {
                for(j = (byte)(i + 1); j < 5; j++)
                {
                    if (SortCount[i] > SortCount[j])
                    {
                        btmp = SortCount[i];
                        SortCount[i] = SortCount[j];
                        SortCount[j] = btmp;
                    }
                }
            }
			
        }
        static bool Royal_Flush()
        {
            if (8 > SortCount[0]) return false;
            return Straight_Flush();
        }
        static bool Straight_Flush()
        {
            return Straight() && Flush() ? true : false;
        }
        static bool FourOfAKind()
        {
            byte count = 1;
            for (byte i = 0; i < 4; i++)
            {
                if (SortCount[i] == SortCount[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > 1) break;
                }
            }
            return count == 4 ? true : false;
        }
        static bool FullHouse()
        {
            byte count = 1, count2 = 1;
            bool checkCount = true;
            for (byte i = 0; i < 4; i++)
            {
                if (SortCount[i] == SortCount[i + 1])
                {
                    if (checkCount) count++;
                    else count2++;
                }
                else
                {
                    if(count < 2)
                    {
                        return false;
                    }
                    checkCount = false;
                }
            }
            if (count == 3 && count2 == 2) return true;
            if (count == 2 && count2 == 3) return true;
            return false;
        }
        static bool Flush()
        {
            char mast = carr[1, 0];
            for (byte i = 1; i < 5; i++)
            {
                if (mast != carr[1, i])
                {
                    return false;
                }
            }
            return true;
        }
        static bool Straight()
        {
            for (byte i = 1; i < 5; i++)
            {
                if (SortCount[i - 1] + 1 != SortCount[i])
                {
                    if (i == 4 && SortCount[0] == 0 && SortCount[4] == 12) break;
                    return false;
                }
            }
            return true;
        }
        static bool ThreeOfAKind()
        {
            byte count = 1;
            for(byte i = 0; i < 4; i++)
            {
                if(SortCount[i] == SortCount[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if(count == 3)
                {
                    break;
                }
            }
            return count != 3 ? false : true;
        }
        static bool TwoPairs()
        {
            byte count = 1, count2 = 1, cyfra = 0;
            bool checkCount = true;
            for (byte i = 0; i < 4; i++)
            {
                if (SortCount[i] == SortCount[i + 1])
                {
                    if (checkCount)
                    {
                        count++;
                        cyfra = SortCount[i];
                        checkCount = false;
                    }
                    else
                    {
                        if(cyfra == SortCount[i + 1]) return false;
                        count2++;
                    }
                }
            }

            if (count == 2 && count2 == 2) return true;
            return false;
        }
        static bool OnePair()
        {
            byte count = 1;
            for (byte i = 0; i < 4; i++)
            {
                if (SortCount[i] == SortCount[i + 1])
                {
                    count++;
                    break;
                }
            }
            return 1 < count ? true : false;
        }
		
		static string[] GetTheCombination()
		{
			return new string[10]
			{
				"Royal Flush",
				"Straight Flush",
				"Four Of A Kind",
				"Full House",
				"Flush",
				"Straight",
				"Three Of A Kind",
				"Two Pairs",
				"One Pair",
				"High Hand"
			};
		}
		
		static string CheckKarti()
		{
			SortStr(skarti);
			string[] arr = GetTheCombination();
			byte count = 0;
			     if(Royal_Flush())    count = 0;
			else if(Straight_Flush()) count = 1;
			else if(FourOfAKind())    count = 2;
			else if(FullHouse())      count = 3;
			else if(Flush()) 		  count = 4;
			else if(Straight())       count = 5;
			else if(ThreeOfAKind())   count = 6;
			else if(TwoPairs())       count = 7;
			else if(OnePair())        count = 8;
			else 			   		  count = 9;
			return arr[count];
		}
		

        static void Main(string[] args)
        {
            strarr[0] = new char[13] {'2', '3', '4', '5',
                '6', '7', '8', '9', '1', 'J', 'Q', 'K', 'A' };
            strarr[1] = new char[4] { 'C', 'D', 'H', 'S' };
			bool[] arr = new bool[10];
            skarti = Console.ReadLine().ToUpper();
			Console.WriteLine(CheckKarti());
        }
    }
}
