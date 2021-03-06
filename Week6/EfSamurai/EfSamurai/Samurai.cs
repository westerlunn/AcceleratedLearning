﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace EfSamurai
{
    public class BattleEvent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public DateTime EventTime { get; set; }
    }
    public class BattleLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BattleEvent> BattleEvents { get; set; }
    }
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }

    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Brutal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BattleLog BattleLog { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }
    }
    public class RealIdentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public Samurai Samurai { get; set; }
    }
    public class HairStyle
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class QuoteType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    public class Quote
    {
        public int Id { get; set; }
        public string QuoteString { get; set; }
        public QuoteType QuoteType { get; set; }
        public Samurai Samurai { get; set; }
    }
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Quote> Quote { get; set; }
        public HairStyle HairStyle { get; set; }
        public RealIdentity RealIdentity { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }

    }
    public class SamuraiInfo
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string BattleNames { get; set; }
    }
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose()
        {
        }

        private class MyLogger : ILogger
        {

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {

                Console.WriteLine(formatter(state, exception));
                Console.WriteLine();

            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}