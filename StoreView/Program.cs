using System;
using StoreView.Menus;
using StoreModel;
using StoreController;
using StoreData;
using StoreData.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Serilog;


namespace StoreView 
{

	class Program 
	{

		static void Main (string[] args)
		{
			//logger configuration
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.File("../Logs.json")
				.CreateLogger();
			/*
			Log.Verbose("Verbose log message");
			Log.Debug("Debug log message");
			Log.Information("Information log message");
			Log.Warning("Warning log message");
			Log.Error("Error log message");
			Log.Fatal("Fatal log message");
			*/

			//get the config file
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build(); 

			//set up db connection
			string connectionString = configuration.GetConnectionString("P0DB-REAL");
			DbContextOptions<P0Context> options = new DbContextOptionsBuilder<P0Context>()
			.UseSqlServer(connectionString)
			.Options;

			//using statement
			using var context = new P0Context(options);

			IMapper shopMapper = new ShopMapper();

			IMenu menu = new MainMenu(new CustomerBL(new CustomerRepoDB(context, shopMapper)), new ProductBL(new ProductRepoDB(context, shopMapper)), new LocationBL(new LocationRepoDB(context, shopMapper)), new InventoryBL(new InventoryRepoDB(context, shopMapper)), new OrderBL(new OrderRepoDB(context, shopMapper)), new CartBL(new CartRepoDB(context, shopMapper)), new CartProductsBL(new CartProductsRepoDB(context, shopMapper)), new OrderItemsBL(new OrderItemRepoDB(context, shopMapper)));
			menu.Start(); 


		}
}
}