﻿using English.Core.Entities;

namespace English.Core.Domain
{
    public class Collection
    {
        public string Name { get; protected set; }
        public List<Word> Word { get; protected set; }
        public Guid Id { get; protected set; }

        protected Collection()
        {
        }
        public Collection(string name, List<Word> word)
        {
            Name = name;
            Word = word;
        }
        public Collection(string name, List<Word> word, Guid id)
        {
            Name = name;
            Word = word;
            Id = id;
        }
    }
}
