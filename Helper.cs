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


		 public static void Menu()
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
						Add(personalRegistrer);
						break;
					case 2:
						Del(personalRegistrer);
						break;
					case 3:
						Edit(personalRegistrer);
						break;
					case 4:
						foreach (var person in personalRegistrer)
						{
							person.ToString();
						}
						break;
					case 5:
						exit = false;
						break;
					default:
						Console.WriteLine("");
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

		static void Add(List<Person> people)
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
			uint.TryParse(Console.ReadLine(), out houseNo);
			Console.WriteLine("5. Numer mieszkania (opcjonale)");
			uint apartamentNo;
			uint.TryParse(Console.ReadLine(), out apartamentNo);

			Address addres = new Address(pcode, ci, stre, houseNo, apartamentNo);
			Person person = new Person(fName, lName, age, gender, addres);
			people.Add(person);
		}
		public static List<Person> Del(List<Person> p_reg)
		{
			Console.WriteLine("Wybierz osobę do usunięcie z listy. Podaj nazwisko");
			string lName = Console.ReadLine();

			for (int i = 0; i < p_reg.Count; i++)
			{
				if (lName == p_reg[i].LastName)
				{
					p_reg.RemoveAt(i);
					Console.WriteLine("Client został usunięty");

					return p_reg;
				}

			}
			return p_reg;
		}
		static List<Person> Edit(List<Person> p_reg)
		{
			string lName;
			
            Console.WriteLine("Podaj nazwisko");
			lName = Console.ReadLine();
            for (int i = 0; i < p_reg.Count; i++)
            {
				if (p_reg[i].LastName==lName)
				{
                    Console.WriteLine("Podaj nowe dane");
					Console.WriteLine("1. Imię");
					var newFName = Console.ReadLine();
					Console.WriteLine("2. Nazwisko");
					var newLName = Console.ReadLine();
					Console.WriteLine("3. Wiek");
					uint nAge;
					uint.TryParse(Console.ReadLine(), out nAge);
					Console.WriteLine("4. Plec (k lub m) ");
					char nGender;
					char.TryParse(Console.ReadLine(), out nGender);
					Console.WriteLine("Podaj dane Adresowe");
					Console.WriteLine("1. Miasto");
					var newCity = Console.ReadLine();
					Console.WriteLine("2. Kod Pocztowy");
					var newPCode = Console.ReadLine();
					Console.WriteLine("3. Ulica");
					var newStreet = Console.ReadLine();
					Console.WriteLine("4. Numer domu");
					uint newHouseNo;
					uint.TryParse(Console.ReadLine(), out newHouseNo);
					Console.WriteLine("5. Numer mieszkania (opcjonale)");
					uint newApartamentNo;
					uint.TryParse(Console.ReadLine(), out newApartamentNo);

					Address newAddres = new Address(newPCode, newCity, newStreet, newHouseNo, newApartamentNo);
					p_reg[i] = new Person(newFName, newLName, nAge, nGender, newAddres);

				}
				return p_reg;
			}
			return p_reg;
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
