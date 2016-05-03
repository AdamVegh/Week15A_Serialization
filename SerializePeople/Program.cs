using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
	[Serializable]
	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public double ID { get; set; }

		public Person()
		{
		}

		public Person(string name, int age, double id)
		{
			Name = name;
			Age = age;
			ID = id;
		}

	}

	class Program
	{
		static void Serialize(Person person)
		{
			FileStream fs = new FileStream("Person.dat", FileMode.Create);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, person);
			fs.Close();
		}

		static void Main(string[] args)
		{
			Person me = new Person("Adam", 25, 1234567890);
			Serialize(me);
		}
	}
}
