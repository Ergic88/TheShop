﻿using System;

namespace TheShop.Log
{
    public class Logger : ILogger
	{
		public void Info(string message)
		{
			Console.WriteLine("Info: " + message);
		}

		public void Error(string message)
		{
			Console.WriteLine("Error: " + message);
		}

		public void Debug(string message)
		{
			Console.WriteLine("Debug: " + message);
		}
	}

}
