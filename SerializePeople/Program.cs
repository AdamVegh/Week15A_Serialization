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
	public class Person: IDeserializationCallback
	{
		public string Name { get; set; }
		[NonSerialized] public int age;
		public double ID { get; set; }

		public int GetAge()
		{
			return age;
		}

		public void OnDeserialization(object sender)
		{
		}

		public Person()
		{
		}

		public Person(string name, int age, double id)
		{
			Name = name;
			this.age = age;
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

		static Person Deserialize()
		{
			Person person = new Person();
			FileStream fs = new FileStream("Person.dat", FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter();

			person = (Person)bf.Deserialize(fs);
			fs.Close();

			return person;
		}

		static void Main(string[] args)
		{
			Person me = new Person("Adam", 25, 1234567890);
			Serialize(me);
			Console.WriteLine("I'm serialized");

			Person myPerson = Deserialize();
			Console.WriteLine("I'm deserialized");

			Console.WriteLine("Name: {0}, Age: {1}, ID: {2}", myPerson.Name, myPerson.GetAge(), myPerson.ID);
			Console.ReadLine();
		}
	}
}
