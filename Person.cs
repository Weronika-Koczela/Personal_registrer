using System;
using System.Collections.Generic;
using System.Text;

namespace Personal_register
{
	class Person
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

		public string FirstName
		{
			get => _firstName;
			set
			{
				if (String.IsNullOrEmpty(_firstName) == false)
					_firstName = value;
			}
		}

		public string LastName
		{
			get => _lastName;
			set
			{
				if (String.IsNullOrEmpty(_firstName) == false)
					_firstName = value;
			}
		}
		public uint Age { get => _age; set => _age = value; }
		public char Gender
		{
			get => _gender; set
			{
				if (_gender == 'k' || _gender == 'l')
					_gender = value;
			}
		}
		internal Address Address
		{
			get => _address; set
			{
				if (_address != null)
				{
					_address = value;
				}
			}
		}
	}
}
