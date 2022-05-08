using System;

namespace Prototype
{   
    public class Enemy
    {
        public int Health;
        public int Damage;
        public int Speed;

        public Enemy(int health, int damage, int speed)
        {
            Health = health;
            Damage = damage;
            Speed = speed;
        }

        public Enemy CloneEnemy()
        {
            return new Enemy(Health, Damage, Speed);
        }

        public void ShowFields()
        {
            Console.WriteLine("Health: " + Health + "\nDamage: " + Damage + "\nSpeed: " + Speed + "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Enemy enemyOne = new Enemy(100, 10, 10);
            Enemy enemyTwo = enemyOne.CloneEnemy();
            
            enemyOne.Health = 150;

            Console.WriteLine("EnemyOne:");
            enemyOne.ShowFields();

            Console.WriteLine("EnemyTwo:");
            enemyTwo.ShowFields();
            

            Console.ReadLine();
        }
    }
}
