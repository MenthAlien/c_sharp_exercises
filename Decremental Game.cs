using System;
using System.Linq;
using System.Collections.Generic;

namespace DecrementalGame
{
	public static class Program
	{
		public static void Main()
		{
			int playersNum;
			int gameNumber;
			int minGameNumber;
			int maxGameNumber;
			int maxUserTry;
			int currentUserTry;
			Random random = new Random();

			Console.WriteLine("\nEnter number of players (1-10):");
			// trying to parse players number
			do
			{
				try
				{
					playersNum = Convert.ToInt32(Console.ReadLine());
					if (playersNum < 1 || playersNum > 10)
					{
						Console.WriteLine("\nEnter the number from 1 to 10!");
					}
					else break;
				}
				catch (System.FormatException e)
				{
					Console.WriteLine("\nEnter the number from 1 to 10!");

				}
			}
			while (true);
			// saving nicknames
			string[] nicknames = new string[playersNum];
			if (playersNum > 1)
			{
				for (int i = 0; i < playersNum; i++)
				{
					Console.WriteLine($"\nEnter nickname of {i + 1} player:");
					nicknames[i] = Console.ReadLine();
				}
			}
			// trying to parse max game number
			Console.WriteLine("\nEnter max game number:");
			do
			{
				try
				{
					maxGameNumber = Convert.ToInt32(Console.ReadLine());
					if (maxGameNumber < playersNum * 10)
					{
						Console.WriteLine($"\nMax number is too small! It\'ll be boring... Enter number more than {playersNum * 10}!");
					}
					else break;
				}
				catch (System.FormatException e)
				{
					Console.WriteLine("\nEnter the number!");
				}
			}
			while (true);

			// multiplayer
			if (playersNum != 1)
			{
				minGameNumber = playersNum * 10;
				gameNumber = random.Next(minGameNumber, maxGameNumber);
				maxUserTry = (gameNumber / 100 + 1) * 4;

				while (gameNumber > 0)
				{
					foreach (string nick in nicknames)
					{
						Console.WriteLine($"\n{nick}'s turn.\nCurrent game number is {gameNumber}.\nPlease select the number from 1 to {maxUserTry} to decrease the game number.");
						do
						{
							try
							{
								currentUserTry = Convert.ToInt32(Console.ReadLine());
								if (currentUserTry < 1 || currentUserTry > maxUserTry)
								{
									Console.WriteLine($"\nYou can only enter the number from 1 to {maxUserTry}. Try again!");
								}
								else break;
							}
							catch (System.FormatException e)
							{
								Console.WriteLine($"\nYou can only enter the number from 1 to {maxUserTry}. Try again!");
							}
						}
						while (true);
						gameNumber -= currentUserTry;
						if (gameNumber <= 0)
						{
							Console.WriteLine($"\n{nick} wins!");
							break;
						}
					}

				}

			}
			else
			{
				minGameNumber = (playersNum + 1) * 10;
				gameNumber = random.Next(minGameNumber, maxGameNumber);
				maxUserTry = (gameNumber / 100 + 1) * 4;

				while (gameNumber > 0)
				{
					// player's turn
					Console.WriteLine($"\nYour turn.\nCurrent game number is {gameNumber}.\nPlease select the number from 1 to {maxUserTry} to decrease the game number.");
					do
					{
						try
						{
							currentUserTry = Convert.ToInt32(Console.ReadLine());
							if (currentUserTry < 1 || currentUserTry > maxUserTry)
							{
								Console.WriteLine($"\nYou can only enter the number from 1 to {maxUserTry}. Try again!");
							}
							else break;
						}
						catch (System.FormatException e)
						{
							Console.WriteLine($"\nYou can only enter the number from 1 to {maxUserTry}. Try again!");
						}
					}
					while (true);

					gameNumber -= currentUserTry;
					if (gameNumber <= 0)
					{
						Console.WriteLine($"\nYou win!");
						break;
					}

					// computer's turn
					if (gameNumber <= maxUserTry)
					{
						currentUserTry = gameNumber;
					}
					else
					{
						currentUserTry = random.Next(1, maxUserTry + 1);
					}
					Console.WriteLine($"\nComputer\'s turn.\nCurrent game number is {gameNumber}.\nComputer decreased game number by {currentUserTry}.");
					gameNumber -= currentUserTry;
					if (gameNumber <= 0)
					{
						Console.WriteLine($"\nComputer wins!");
						break;
					}
				}
			}
		}
	}
}