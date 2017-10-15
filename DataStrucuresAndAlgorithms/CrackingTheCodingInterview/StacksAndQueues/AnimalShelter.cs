using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class AnimalShelter
    {
        private AnimalQueue cats;
        private AnimalQueue dogs;

        public AnimalShelter()
        {
            cats = new AnimalQueue();
            dogs = new AnimalQueue();
        }

        public void Enqueue(AnimalType type, string name)
        {
            var animal = new Animal(type, name);
            if (type == AnimalType.Cat)
                cats.Enqueue(animal);
            else
                dogs.Enqueue(animal);
        }
        public Animal DequeueAny()
        {
            try
            {
                var cmpr = cats.Peek().ArrivalTime.CompareTo(dogs.Peek().ArrivalTime);
                if (cmpr < 0)
                {
                    if (!cats.IsEmpty())
                        return cats.Dequeue();
                    else
                        return dogs.Dequeue();
                }
                else
                {
                    if (!dogs.IsEmpty())
                        return dogs.Dequeue();
                    else
                        return cats.Dequeue();
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
        public Animal DequeueDog()
        {
            if (!dogs.IsEmpty())
                return dogs.Dequeue();
            else
                return null;
        }
        public Animal DequeueCat()
        {
            if (cats.IsEmpty())
                return cats.Dequeue();
            else
                return null;
        }

    }
    public class AnimalQueue
    {
        private LinkedList<Animal> data;
        public AnimalQueue()
        {
            data = new LinkedList<Animal>();            
        }
        public void Enqueue(Animal animal)
        {
            data.AddLast(animal);
        }
        public Animal Dequeue()
        {
            if (data.Count() == 0)
                throw new Exception("Queue is empty");
            var val = data.First();
            data.RemoveFirst();
            return val;
        }
        public Animal Peek()
        {
            if (data.Count() == 0)
                throw new Exception("Queue is empty");
            return data.First();
        }
        public bool IsEmpty()
        {
            return data.Count() == 0;
        }
    }


    public enum AnimalType
    {
        Cat, Dog
    }
    public class Animal
    {        
        private AnimalType type;
        private DateTime arrivalTime;

        public Animal(AnimalType type, string name)
        {
            this.type = type;
            this.Name = name;
            arrivalTime = DateTime.Now;
        }
        public String Type
        {
            get
            {
                return type.ToString();
            }
        }
        public string Name { get; set; }
        public DateTime ArrivalTime
        {
            get
            {
                return arrivalTime;
            }
        }
    }
 

}
