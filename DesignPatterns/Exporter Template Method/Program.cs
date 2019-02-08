using System;

namespace Exporter_Template_Method
{
	internal abstract class DataExporter
	{
		//This will not vary as the data is read from sql only
		private static void ReadData()
		{
			Console.WriteLine("Reading data from SqlServer");
		}

		//This will not vary as the format of report is fixed
		private static void FormatData()
		{
			Console.WriteLine("Formating the data as per requirements");
		}

		// This may vary based on target file type chosen
		protected abstract void ExportData();

		//This is the template method that the client will use
		public void ExportFormatedData()
		{
			ReadData();
			FormatData();
			ExportData();
		}
	}

	internal class ExcelExporter : DataExporter
	{
		protected override void ExportData()
		{
			Console.WriteLine("Exporting data to an Excel file.");
		}
	}

	internal class PdfExporter : DataExporter
	{
		protected override void ExportData()
		{
			Console.WriteLine("Exporting data to a PDF file.");
		}
	}

	internal class Program
	{
		private static void Main()
		{
			DataExporter exporter = new ExcelExporter();
			exporter.ExportFormatedData();

			Console.WriteLine();

			exporter = new PdfExporter();
			exporter.ExportFormatedData();

		}
	}
}
