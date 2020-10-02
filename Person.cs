using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace Personal_register
{
	[Serializable]
	[XmlRoot("Osoba")]
	class Person : IComparable<Person>
	{
		string _firstName;
		string _lastName;
		uint _age;
		char _gender;
		Address _address;

		public Person(string fName, string lName, uint age, char gender, Address address)
		{
			_firstName = fName;
			_lastName = lName;
			_age = age;
			_gender = gender;
			_address = address;
		}

		[XmlElement("Imie")]
		public string FirstName
		{
			get => _firstName;
			set
			{
				if (String.IsNullOrEmpty(_firstName) == false)
					_firstName = value;
			}
		}
		[XmlElement("Nazwisko")]
		public string LastName
		{
			get => _lastName;
			set
			{
				if (String.IsNullOrEmpty(_firstName) == false)
					_firstName = value;
			}
		}
		[XmlElement("Wiek")]
		public uint Age { get => _age; set => _age = value; }
		[XmlElement("Plec")]
		public char Gender
		{
			get => _gender; set
			{
				if (_gender == 'k' || _gender == 'l')
					_gender = value;
			}
		}
		[XmlElement("Adres")]
		public Address Address
		{
			get => _address; set
			{
				if (_address != null)
				{
					_address = value;
				}
			}
		}

		public int CompareTo(Person other)
		{
			int result = FirstName.CompareTo(other.FirstName);
			if (result == 0) 
			{
				result = LastName.CompareTo(other.LastName);
			}
			return result;
		}

        public override string ToString()
		{
			return $"Imię i nazwisko : {_firstName} {_lastName} \n wiek: {_age} \n płeć : {_gender} \n adres: {_address} ";
		}



	}

}
