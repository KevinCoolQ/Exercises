using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    #region Fields
    const int _mine = -1;
	static readonly int _height = Console.WindowHeight;
	static readonly int _width = Console.WindowWidth;
	static readonly Random _random = new Random();
	static readonly float _mineRatio = .1f;
	static readonly int _mineCount = (int)(_width * _height * _mineRatio);
	static (int Value, bool Visible)[,] _board;
	static (int Column, int Row) _position = (_width / 2, _height / 2);
	private enum ExitState { Win, Lose, Quit };
	#endregion

	static void Main(string[] args)
	{
		GenerateBoard(); // Initiele opzet: waar staan mijntjes, hoeveel buren zijn een mijn, ...
		RenderBoard(); // Wordt veel gebruikt, ook in EventLoop(), om bord te hertekenen
		EventLoop(); // Leest ingetikte toetsen en verwerkt deze, dwz hertekent bord, stopt eventueel, ...
	}

	private static bool IsConsoleResized()
	{
			if (Console.WindowHeight != _height || Console.WindowWidth != _width)
			{
				Console.Clear();
				Quit(ExitState.Quit, "Console resized: MineSweeper is closed.");
				return true;
			}
		return false;
	}

	private static void Quit(ExitState state, string message)
	{
		Console.SetCursorPosition(0, _height - 1);
		Console.Write(message);

		switch(state)
		{
			case ExitState.Lose:
				{
					PlaySound(@"..\..\..\Explosion.wav");
				}
				break;
			case ExitState.Win:
				{
					PlaySound(@"..\..\..\Victory.wav");
				}
				break;
			default:
				break;
		}	
		Console.ReadLine();
		Console.Clear();
	}

	private static void PlaySound(string path)
	{
		// .NET Frameworks:
		//System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
		//player.Play();
		// .NET Core:
		var waveOut = new WaveOutEvent();
		var wavReader = new MediaFoundationReader(path);
		waveOut.Init(wavReader);
		waveOut.Play();
		// Give sound time to play:
		while (waveOut.PlaybackState == PlaybackState.Playing)
		{
			System.Threading.Thread.Sleep(1000);
		}
	}

	private static void EventLoop()
	{
		while (true)
		{
			if (IsConsoleResized())
				break;

			Console.SetCursorPosition(_position.Column, _position.Row);
			switch (Console.ReadKey(true).Key)
			{
				case ConsoleKey.UpArrow:
					_position.Row = Math.Max(_position.Row - 1, 0);
					break;
				case ConsoleKey.DownArrow:
					_position.Row = Math.Min(_position.Row + 1, _height - 1);
					break;
				case ConsoleKey.LeftArrow:
					_position.Column = Math.Max(_position.Column - 1, 0);
					break;
				case ConsoleKey.RightArrow:
					_position.Column = Math.Min(_position.Column + 1, _width - 1);
					break;
				case ConsoleKey.Enter:
					if (!_board[_position.Column, _position.Row].Visible)
					{
						if (_board[_position.Column, _position.Row].Value == _mine)
						{
							for (int column = 0; column < _width; column++)
							{
								for (int row = 0; row < _height; row++)
								{
									_board[column, row].Visible = true;
								}
							}
							RenderBoard();
							Quit(ExitState.Lose, "You lost!");
							return;
						}
						else if (_board[_position.Column, _position.Row].Value == 0)
						{
							Reveal(_position.Column, _position.Row);
							RenderBoard();
						}
						else
						{
							_board[_position.Column, _position.Row].Visible = true;
							RenderBoard();
						}
						int visibleCount = 0;
						for (int column = 0; column < _width; column++)
						{
							for (int row = 0; row < _height; row++)
							{
								if (_board[column, row].Visible)
								{
									visibleCount++;
								}
							}
						}
						if (visibleCount == _width * _height - _mineCount)
						{
							Quit(ExitState.Win, "You Win.");
							return;
						}
					}
					break;
				case ConsoleKey.Escape:
					Quit(ExitState.Quit, "Minesweeper is closed.");
					return;
			}
		}
	}

	/*
	static IEnumerable<(int Column, int Row)> AdjacentTiles(int column, int row)
	{
		//    A B C
		//    D + E
		//    F G H

		// A
		if (row > 0 && column > 0) yield return (row - 1, column - 1);
		// B
		if (row > 0) yield return (row - 1, column);
		// C
		if (row > 0 && column < _width - 1) yield return (row - 1, column + 1);
		// D
		if (column > 0) yield return (row, column - 1);
		// E
		if (column < _width - 1) yield return (row, column + 1);
		// F
		if (row < _height - 1 && column > 0) yield return (row + 1, column - 1);
		// G
		if (row < _height - 1) yield return (row + 1, column);
		// H
		if (row < _height - 1 && column < _width - 1) yield return (row + 1, column + 1);
	}
    */

	private static void GenerateBoard()
	{
		// We initialiseren het bord: een array van int/bool tuples (een tuple: combinatie van 2 elementen, tussen ronde haken)
		_board = new (int Value, bool Visible)[_width, _height];
		var coordinates = new List<(int Column, int Row)>(); // lijst laat toe te weten waar al een mijn staat
		// Initialisatie van lijst coordinaten: voor elke cel op het bord maken we een coordinaat aan
		for (int row = 0; row < _height; row++)
		{
			for (int column = 0; column < _width; column++)			
			{
				coordinates.Add((column, row));
			}
		}
		for (int i = 0; i < _mineCount; i++)
		{
			// Op deze willekeurige coordinaat wordt een mijn geplaatst...
			int randomIndex = _random.Next(0, coordinates.Count);
			(int column, int row) = coordinates[randomIndex];
			// Verwijder de coordinaat waarop de mijn geplaatst werd, uit de lijst om te voorkomen dat er nog eens een mijn op komt
			coordinates.RemoveAt(randomIndex);
			// Mijn plaatsen en zet visible false: cel onzichtbaar bij opstarten ...
			_board[column, row] = (_mine, false);

			// Voor de plaatsen rond de mijn geldt: tel eentje op bij getal dat er staat
			for(int columnRunner = -1; columnRunner < 2; columnRunner++)
			{
				for(int rowRunner = -1; rowRunner < 2; rowRunner++)
				{
					int columnIndex = column + columnRunner;
					int rowIndex = row + rowRunner;
					if(!(columnIndex == column && rowIndex == row) && columnIndex >= 0 && rowIndex >= 0 && columnIndex < _width && rowIndex < _height) // this would be the mine itself or outside the board
					{
						_board[columnIndex, rowIndex] = (_board[columnIndex, rowIndex].Value + 1, false);
					}
				}
			}
			/*
			// Yield implementatie:
			foreach (var tile in AdjacentTiles(Column, Row))
			{
				if (_board[tile.Column, tile.Row].Value != _mine)
				{
					_board[tile.Column, tile.Row].Value++;
				}
			}
			*/
		}
	}

	private static char Render(int value) => value switch
	{
		_mine => '@',
		0 => ' ',
		1 => '1',
		2 => '2',
		3 => '3',
		4 => '4',
		5 => '5',
		6 => '6',
		7 => '7',
		8 => '8',
		_ => throw new NotImplementedException(),
	};

	private static void RenderBoard()
	{
		StringBuilder stringBuilder = new StringBuilder(_width * _height);
		for (int row = 0; row < _height; row++)
		{
			for (int column = 0; column < _width; column++)
			{
				stringBuilder.Append(_board[column, row].Visible ? Render(_board[column, row].Value): '█');
			}
		}
		Console.CursorVisible = false;
		Console.SetCursorPosition(0, 0);
		Console.Write(stringBuilder.ToString());
		Console.CursorVisible = true;
	}

	/// <summary>
	/// Reveal(): recursieve functie
	/// </summary>
	/// <param name="column"></param>
	/// <param name="row"></param>
	private static void Reveal(int column, int row)
	{
		_board[column, row].Visible = true;
		// Stopcriterium 1: indien we een mijn in de buurt hebben, maken we niets verder zichtbaar!
		if (_board[column, row].Value != 0) return;
		for (int columnRunner = -1; columnRunner < 2; columnRunner++)
		{
			for (int rowRunner = -1; rowRunner < 2; rowRunner++)
			{
				int columnIndex = column + columnRunner;
				int rowIndex = row + rowRunner;
				if (!(columnIndex == column && rowIndex == row) && columnIndex >= 0 && rowIndex >= 0 && columnIndex < _width && rowIndex < _height) // this would be the mine itself or outside the board
				{
					// Stopcriterium 2: als we in deze buurt al waren om zichtbaar te maken, dan doen we niet voort
					if(!_board[columnIndex, rowIndex].Visible)
					{
						Reveal(columnIndex, rowIndex);
					}
				}
			}
		}
		/*
		// yield implementation:
		if (_board[column, row].Value == 0)
		{
			foreach (var (myColumn, myRow) in AdjacentTiles(column, row))
			{
				if (!_board[myColumn, myRow].Visible)
				{
					Reveal(myColumn, myRow);
				}
			}
		}
		*/
	}
}
