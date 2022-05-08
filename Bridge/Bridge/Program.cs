using System;

namespace Bridge
{   
    // Levels.
    class Level
    {
        public readonly string StringLevel;
        public readonly int FieldFactor;

        protected Level(string level, int fieldFactor)
        {
            StringLevel = level;
            FieldFactor = fieldFactor;
        }
    }

    class Easy: Level
    {
        public Easy(): base("Easy", 1) {}
    }


    class Normal: Level
    {
        public Normal(): base("Normal", 2) {}
    }

    class Hard: Level
    {
        public Hard(): base("Hard", 3) {}
    }

    // Enemies.
    abstract class Enemy
    {   
        public readonly string Type;
        public int Health;
        public int Damage;
        public int Speed;

        protected Level Level;

        protected Enemy(string type, Level level, int health, int damage, int speed)
        {   
            Type = type;
            Level = level;
            Health = health * level.FieldFactor;
            Damage = damage  * level.FieldFactor;
            Speed = speed  * level.FieldFactor;
        }

        public void ShowFields()
        {
            Console.WriteLine("Enemy type: " + Type + "\nHis level: " + Level.StringLevel + "\nHis Health: " + Health + "\nHis Daamge: " + Damage + "\nHis Speed: " + Speed + "\n");
        }
    }

    class Zombie: Enemy
    {
        public Zombie(Level level): base("Zombie", level, 50, 3, 1){}
    }

    class Skeleton: Enemy
    {   
        public Skeleton(Level level): base("Skeleton", level, 80, 5, 2){}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Skeleton SkeletonFirst = new Skeleton(new Easy());
            Skeleton SkeletonSecond = new Skeleton(new Normal());
            Skeleton SkeletonThird = new Skeleton(new Hard());
            Zombie ZombieFirst = new Zombie(new Easy());
            Zombie ZombieSecond = new Zombie(new Hard());

            SkeletonFirst.ShowFields();
            SkeletonSecond.ShowFields();
            SkeletonThird.ShowFields();
            ZombieFirst.ShowFields();
            ZombieSecond.ShowFields();

            Console.ReadLine();
        }
    }
}
