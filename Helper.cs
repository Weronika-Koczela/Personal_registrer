using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Personal_register
{

	static class Helper

	{


		static List<Person> personalRegistrer = new List<Person>();


		static void Menu()
		{
			Deserialize();

			int ans;
			bool exit = false;


			while (!exit)
			{
				Console.WriteLine("************* Rejestr Osobowy ***************");
				Console.WriteLine("Wybierz Opcję");
				DisplayMenu();
				int.TryParse(Console.ReadLine(), out ans);
				switch (ans)
				{
					case 1:
						Add();
						break;
					case 2:

						break;
					case 3:
						break;
					case 4:
						break;
					case 5:
						break;
					default:
						break;



				}
			}


		}


		static void DisplayMenu()
		{
			Console.WriteLine("Wybierz opcje :");
			Console.WriteLine("[1] Dodaj uzytkownika");
			Console.WriteLine("[2] Usun uzytkownika");
			Console.WriteLine("[3] Edytuj uzytkownika ");
			Console.WriteLine("[4] Wyswietl uzytkownika");
			Console.WriteLine("[5] Wyjdz");
		}

		static void Add()
        {
            Console.WriteLine("Podaj dane osoby");
            Console.WriteLine("1. Imię");
			var fName = Console.ReadLine();
			Console.WriteLine("2. Nazwisko");
			var lName = Console.ReadLine();
			Console.WriteLine("3. Wiek");
			uint age;
			uint.TryParse(Console.ReadLine(), out age);
			Console.WriteLine("4. Plec (k lub m) ");
			char gender;
			char.TryParse(Console.ReadLine(), out gender);
            Console.WriteLine("Podaj dane Adresowe");
            Console.WriteLine("1. Miasto");
			var ci = Console.ReadLine();
			Console.WriteLine("2. Kod Pocztowy");
			var pcode = Console.ReadLine();
			Console.WriteLine("3. Ulica");
			var stre = Console.ReadLine();
			Console.WriteLine("4. Numer domu");
			uint houseNo;
			uint.TryParse(Console.ReadLine(),out houseNo);
			Console.WriteLine("5. Numer mieszkania (opcjonale)");
			uint apartamentNo;
			uint.TryParse(Console.ReadLine(), out apartamentNo);

			Address addres = new Address(pcode, ci, stre, houseNo, apartamentNo);
			Person person = new Person(fName,lName,age,gender,addres);
			personalRegistrer.Add(person);
		}





		static void Serialize(List<Person> p_reg)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

			try
			{
				using (TextWriter writer = new StreamWriter(@"./person_reg.xml"))
				{
					serializer.Serialize(writer, p_reg);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}


		}
		static void Deserialize()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

			personalRegistrer = new List<Person>();

			try
			{
				using (TextReader reader = new StreamReader(@"./person_reg.xml"))
				{
					var obj = serializer.Deserialize(reader);

					personalRegistrer = (List<Person>)obj;



				}
            }
			catch (Exception)
			{

			}

		}
	}
}
