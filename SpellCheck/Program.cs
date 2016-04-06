using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpellCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = System.AppDomain.CurrentDomain.BaseDirectory;
            var aff = Path.Combine("Assets", "fr-classique.aff");
            var dic = Path.Combine("Assets", "fr-classique.dic");
            var dat = Path.Combine("Assets", "th_en_us_new.dat");

            using (Hunspell hunspell = new Hunspell(aff, dic))
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("Hunspell - Spell Checking Functions");
                Console.WriteLine("Language : French\n");

                Console.WriteLine("Check if the word 'platre' is spelled correct");
                bool correct = hunspell.Spell("platre");
                Console.WriteLine("'platre' " + (correct ? " is correct" : " is not correct"));

                Console.WriteLine("");
                Console.WriteLine("Make suggestions for the word 'pltr'");
                List<string> suggestions = hunspell.Suggest("pltr");
                Console.WriteLine("There are " + suggestions.Count.ToString() + " suggestions");
                foreach (string suggestion in suggestions)
                {
                    Console.WriteLine("Suggestion is: " + suggestion);
                }

                Console.WriteLine("");
                Console.WriteLine("Analyze the word 'manger'");
                List<string> morphs = hunspell.Analyze("manger");
                foreach (string morph in morphs)
                {
                    Console.WriteLine("Morph is: " + morph);
                }

                Console.WriteLine("");
                Console.WriteLine("Find the word stem of the word 'fût'");
                List<string> stems = hunspell.Stem("fût");
                foreach (string stem in stems)
                {
                    Console.WriteLine("Word Stem is: " + stem);
                }

                // NOT WORKING
                //Console.WriteLine("");
                //Console.WriteLine("Generate the plural of 'fille' by providing sample 'garçons'");
                //List<string> generated = hunspell.Generate("fille", "garçons");
                //foreach (string stem in generated)
                //{
                //    Console.WriteLine("Generated word is: " + stem);
                //}

                Console.WriteLine("");
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("Thesaurus - Synonym Finder");
                Console.WriteLine("Language : English\n");

                MyThes thes = new MyThes(dat);
                Console.WriteLine("Get the synonyms of the plural word 'route'");
                Console.WriteLine("hunspell must be used to get the word stem 'car' via Stem().");
                Console.WriteLine("hunspell generates the plural forms " +
                                  "of the synonyms via Generate()");
                ThesResult tr = thes.Lookup("route", hunspell);

                if (tr.IsGenerated)
                    Console.WriteLine("Generated over stem (The original word form wasn't in the thesaurus)");
                foreach (ThesMeaning meaning in tr.Meanings)
                {
                    Console.WriteLine("  Meaning: " + meaning.Description);
                    foreach (string synonym in meaning.Synonyms)
                    {
                        Console.WriteLine("    Synonym: " + synonym);
                    }
                }
            }

            // NOT WORKING
            //Console.WriteLine("");
            //Console.WriteLine("*******************************************************************");
            //Console.WriteLine("Hyphen - Synonym Finder");
            //Console.WriteLine("Language : French\n");

            //using (Hyphen hyphen = new Hyphen(dic))
            //{
            //    Console.WriteLine("Get the hyphenation of the word 'arc-en-ciel'");
            //    HyphenResult hyphenated = hyphen.Hyphenate("arc-en-ciel");
            //    Console.WriteLine("'arc-en-ciel' is hyphenated as: " + hyphenated.HyphenatedWord);
            //}

            Console.Read();
        }
    }
}
