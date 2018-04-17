using System;
using System.Collections.Generic;
using EfSamurai;
using Microsoft.EntityFrameworkCore;

namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddSomeSamurais();
            //AddSomeBattles();
            AddOneSamuraiWithRelatedData();
            //ClearDatabase();
        }

        private static void AddOneSamurai()
        {
            var samurai = new Samurai { Name = "Zelda" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void AddSomeSamurais()
        {
            var samuraiList = new List<Samurai>
            {
                new Samurai {Name = "Bella"},
                new Samurai {Name = "Kocko"},
                new Samurai {Name = "Bäng"}

            }
            ;
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuraiList);
                context.SaveChanges();
            }
        }

        private static void AddSomeBattles()
        {
            var battleEvent = new BattleEvent
            {
                Description = "It is war",
                Summary = "war",
                EventTime = new DateTime(1704, 3, 9)
            };

            var eventList = new List<BattleEvent>{ battleEvent};

            var log = new BattleLog {BattleEvents = eventList, Name = "Log"};

            var battleList = new List<Battle>
            {
                new Battle
                {
                    BattleLog = log,
                    Name = "Battle",
                    Description = "Bad ass battle",
                    Brutal = true,
                    StartDate = new DateTime(1704, 3, 2),
                    EndDate = new DateTime(1704, 3, 12)
                }
            };

            using (var context = new SamuraiContext())
            {
                context.Battles.AddRange(battleList);
                context.SaveChanges();
            }

        }

        private static void AddOneSamuraiWithRelatedData()
        {
            var samurai = new Samurai
            {
                Name = "Mördar-Albert",
                Age = 35,
                HairStyle = new HairStyle { Name = "Tuppkam"},
                Quote = new List<Quote>
                {
                    new Quote{ QuoteString = "Våld löser allt", QuoteType = new QuoteType {Type = "Awesome"}},
                    new Quote{ QuoteString = "Det som inte dödar härdar", QuoteType = new QuoteType {Type = "Cheesy"}}
                },
            };

            samurai.RealIdentity = new RealIdentity{RealName = "Karl-Alfred", Samurai = samurai};

            var battleEvent = new BattleEvent
            {
                Description = "The kings head fell off",
                Summary = "Kings head",
                EventTime = new DateTime(1804, 3, 9)
            };

            var eventList = new List<BattleEvent> { battleEvent };

            var log = new BattleLog { BattleEvents = eventList, Name = "Hoth log" };

            var battle = new Battle
            {
                BattleLog = log,
                Name = "Hoth battle",
                Description = "Brutal battle on Hoth",
                Brutal = true,
                StartDate = new DateTime(1804, 3, 5),
                EndDate = new DateTime(1804, 3, 9)
            };

            var samuraiBattle = new SamuraiBattle {Battle = battle, Samurai = samurai};

            samurai.SamuraiBattles = new List<SamuraiBattle> {samuraiBattle};
            battle.SamuraiBattles = new List<SamuraiBattle> {samuraiBattle};

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.Battles.Add(battle);
                context.SaveChanges();
            }
        }

        private static void ClearDatabase()
        {
            var listOfTableNames = new List<string>();
            listOfTableNames.Add("Quote");
            listOfTableNames.Add("QuoteType");
            //listOfTableNames.Add("SamuraiBattle");
            listOfTableNames.Add("Samurais");
            listOfTableNames.Add("HairStyle");
            listOfTableNames.Add("BattleEvent");
            listOfTableNames.Add("Battles");
            listOfTableNames.Add("BattleLog");
            
            
            using (var context = new SamuraiContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM SamuraiBattle");
                foreach (var tableName in listOfTableNames)
                {
                    context.Database.ExecuteSqlCommand("DELETE FROM [" + tableName + "] DBCC CHECKIDENT (["+ tableName +"], RESEED, 0)");
                    //context.Database.ExecuteSqlCommand("DELETE FROM [" + tableName + "]");
                    //+
                    //"DBCC CHECKIDENT (EfSamurai.dbo.["+ tableName +"], RESEED, [0|1])");
                }

                context.SaveChanges();
            }
                
        }
    }
}
