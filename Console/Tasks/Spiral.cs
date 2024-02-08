using System;
namespace Tester
{
	class TestApplication
	{
		static void Main() 
		{
			const byte bColumn = 3;
			const byte bRow = 3;
			byte Row = 0, 
				 Column = 0, 
				 napravlenie = 0, 
				 i = 0, j = 0,
				 diya = 0,
				 spiral = 0,
				 count = 0;
			char[,] arr = new char[bRow, bColumn];

			for(i = 0; i < arr.Length; i++)
			{
				arr[Row, Column] = (char)(i + 1 + '0');
				
				switch(napravlenie)
				{
					case 0:
						Column++;
						break;
					case 1:
						Row++;
						break;
					case 2:
						Column--;
						break;
					case 3:
						Row--;
						break;	
				}
				
				if(diya == 1 - spiral)
				{
					diya = 0;
					napravlenie++;
					count++;
					if(count == 3) spiral++;
					if(napravlenie == 4) { napravlenie = 0; }
				}
				else
				{
					diya++;
				}
			}
			
			for(i = 0; i < bRow; i++)
			{
				for(j = 0; j < bColumn; j++)
				{
					Console.Write(arr[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}