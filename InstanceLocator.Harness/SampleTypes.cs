using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.Harness
{
    class Person
    {
        private Address _address;
        private string _name;
        private bool _employee;

        public Person(Address addr, string Name, bool employee)
        {
            this._address = addr;
            this._name = Name;
            this._employee = employee;
        }
    }

    class Address
    {
        private AddressType _type;
        private string _street1, _street2;
        
        public Address(AddressType type, string Street1, string Street2)
        {
            this._type = type;
            this._street1 = Street1;
            this._street2 = Street2;
        }
    }

    class Society
    {
        private Person[] _person;
        private SocietyType[] _type;

        public Society(Person[] persons, SocietyType[] types)
        {
            this._person = persons;
            this._type = types;
        }
    }

    enum AddressType
    {
        Home,
        Work
    }

    enum PersonType
    {
        Good,
        Rude,
        Nice,
        Awesome
    }

    enum SocietyType
    {
        Agricultural = 12,
        Industrial = 14,
        Mechanized = 2
    }
}
