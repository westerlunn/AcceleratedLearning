using System;
using System.Collections.Generic;
using System.Linq;
using EfSamurai;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SamuraiContext();
            //AddSomeSamurais();
            //AddSomeBattles();
            //AddOneSamuraiWithRelatedData();
            //ClearDatabase();
            //ListAllSamuraiNames();
            //ListAllSamuraiNames_OrderByNames();
            /*
            var alias = AllSamuraiNameWithAlias();
            foreach (var alia in alias)
            {
                Console.WriteLine(alia);
            }
            */
            //ListAllBattlesWithLog(new DateTime(1700, 1, 1), new DateTime(1805, 12, 12), true);
            //PrintInfoList(GetSamuraiInfo());
            context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

            GetBattlesForSamurai("Mördar-Albert", context);
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
            listOfTableNames.Add("Samurais");
            listOfTableNames.Add("HairStyle");
            listOfTableNames.Add("RealIdentity");
            listOfTableNames.Add("BattleEvent");
            listOfTableNames.Add("Battles");
            listOfTableNames.Add("BattleLog");
            
            
            using (var context = new SamuraiContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM SamuraiBattle");
                foreach (var tableName in listOfTableNames)
                {
                    context.Database.ExecuteSqlCommand("DELETE FROM [" + tableName + "] DBCC CHECKIDENT (["+ tableName +"], RESEED, 0)");
                    
                }

                context.SaveChanges();
            }
                
        }

        private static void ListAllSamuraiNames()
        {
            using (var context = new SamuraiContext())
            {
                Console.WriteLine("Samurai names:");
                var samurais = context.Samurais.ToList();
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void ListAllSamuraiNames_OrderByNames()
        {
            Console.WriteLine("Samurai names ordered by names:");
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.OrderBy(Samurais => Samurais.Name).ToList();
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static List<string> AllSamuraiNameWithAlias()
        {
            var list = new List<string>();
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                var realIdentities = context.Samurais.Select(x => x.RealIdentity).ToList();

                foreach (var samurai in samurais)
                {
                    if (samurai.RealIdentity != null)
                    {
                        list.Add($"{samurai.RealIdentity.RealName} alias {samurai.Name}");
                    }

                //realIdentities.Where(x => x.Samurai.Id == samurai.Id).Select(x => x.RealName).First()
                    //if (realIdentity.Samurai.Id == samurai.Id)
                    //{
                    //    list.Add($"{realIdentity.RealName} alias {samurai.Name}");
                    //}
                }

            }
            return list;
        }

        private static void ListAllBattlesWithLog(DateTime from, DateTime to, bool isBrutal)
        {
            using (var context = new SamuraiContext())
            {
                var battles = context.Battles.Where(x => x.Brutal == isBrutal)
                    .Where(x => x.StartDate > from && x.StartDate < to)
                    .Where(x => x.EndDate < to && x.EndDate > from)
                    .Include(x => x.BattleLog)
                    .Include(x => x.BattleLog.BattleEvents)
                    .ToList();

                foreach (var battle in battles)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine($"{"Name of battle:", -20 }{battle.Name}");
                    Console.WriteLine($"{"Log Name:", -20}{battle.BattleLog.Name}");
                    foreach (var e in battle.BattleLog.BattleEvents)
                    {
                        Console.WriteLine($"{"Event:", -20}{e.Summary}");
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                }
            }

            
        }

        private static List<SamuraiInfo> GetSamuraiInfo()
        {
            var samuraiList = new List<SamuraiInfo>();

            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.Include(x => x.SamuraiBattles)
                    .Include(x => x.RealIdentity)
                    .ToList();
                var battles = context.Battles.ToList();

                foreach (var samurai in samurais)
                {
                    var id = samurai.SamuraiBattles.Select(x => x.BattleId).ToList();
                    var info = new SamuraiInfo
                    {
                        Name = samurai.Name,
                    };
                    if (samurai.RealIdentity != null)
                    {
                        info.RealName = samurai.RealIdentity.RealName;
                    }
                    if (id.Count != 0)
                    {
                        var stringList = new List<string>();
                        foreach (var i in id)
                        {
                            stringList.Add(battles.Where(x => x.Id == i).Select(x => x.Name).Single());
                        }

                        info.BattleNames = string.Join(',', stringList);
                    }
                    samuraiList.Add(info);
                }
            }

            return samuraiList;
        }

        private static void PrintInfoList(List<SamuraiInfo> samuraiInfo)
        {
            Console.WriteLine($"{"Name", -20}{"Real Name", -20}Battles");
            Console.WriteLine("-------------------------------------------------");
            foreach (var info in samuraiInfo)
            {
            Console.WriteLine($"{info.Name, -20}{info.RealName, -20}{info.BattleNames}");

            }
        }

        private static void GetBattlesForSamurai(string samuraiName, SamuraiContext context)
        {
            
                var samurais = context.Samurais.Where(x => x.Name == samuraiName)
                    .Include(x => x.SamuraiBattles)
                    .ToList();
                var battles = context.Battles.ToList();

                foreach (var samurai in samurais)
                {
                    Console.WriteLine($"Samurai '{samuraiName}' participated in the following battles:\n");
                    Console.WriteLine($"{"Id", -20}{"Name", -20}");

                    var samuraiBattle = battles
                        .Where(x => x.SamuraiBattles.All(y => y.Samurai.Id == samurai.Id))
                        .ToList();

                    foreach (var battle in samuraiBattle)
                    {
                        Console.WriteLine($"{battle.Id, -20}{battle.Name}");
                    }
                }
            }
        

    }
}
