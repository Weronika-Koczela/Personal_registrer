using System;
using System.Collections.Generic;
using System.Text;

namespace Personal_register
{
	class Address
	{
		string _postCode;
		string _city;
		string _street;
		uint _houseNumber;
		uint _apartamentNumber;

		public Address(string postCode, string city, string street, uint houseNum, uint apartamentNum =0)
		{
			_postCode = postCode;
			_city = city;
			_street = street;
			_houseNumber = houseNum;
			_apartamentNumber = apartamentNum;
				
		}
		public string PostCode
		{
			get => _postCode;
			set
			{
				if (_postCode.Length <= 6)
				{
					_postCode = value;
				}
			}
		}

		public string City
		{
			get => _city;
			
			set
			{
				if( String.IsNullOrEmpty(_city) == false)
				_city = value;
			}
		}

		public string Street { get => _street; set
			{
				if (String.IsNullOrEmpty(_city) == false)
					_city = value;
			}
		}

		public uint HouseNumber { get => _houseNumber; set => _houseNumber = value; }
		public uint ApartamentNumber { get => _apartamentNumber; set => _apartamentNumber = value; }
	}
}
