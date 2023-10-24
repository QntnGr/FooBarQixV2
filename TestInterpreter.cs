using NUnit.Framework;
//  Les using inutiles sont à enlever => ce n'est pas grave, mais c'est toujours plus lisible
//  de n'importer que ce qui est nécessaire
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBarQixV2
{
    internal class TestInterpreter
    {

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "FooFoo")]
        [TestCase(4, "4")]
        [TestCase(5, "BarBar")]
        [TestCase(6, "Foo")]
        [TestCase(7, "QixQix")]
        [TestCase(8, "8")]
        [TestCase(9, "Foo")]
        [TestCase(10, "Bar*")]
        [TestCase(13, "Foo")]
        [TestCase(15, "FooBarBar")]
        [TestCase(21, "FooQix")]
        [TestCase(33, "FooFooFoo")]
        [TestCase(51, "FooBar")]
        [TestCase(53, "BarFoo")]
        [TestCase(101, "1*1")]
        [TestCase(303, "FooFoo*Foo")]
        [TestCase(105, "FooBarQix*Bar")]
        [TestCase(10101, "FooQix**")]
        
        // Il y a un peu d'idée, mais le contrat de base n'est pas bien respecté
        // Voici ce que dit l'énoncé :
        // "Vous devez implémenter une fonction/méthode `string Compute(string input)` qui implémente les règles suivantes" :
        // if (input % 3) => Foo
        // if (input % 5) => Bar
        // if (input % 7) => Qix
        // if input[n] = 3/5/7 => Foo/Bar/Qix (Je zappe le remplacement par étoile)
        // Après le test, écrire l'interface aurait été un bon moyen de ne pas trop te perdre
        public void TestNumberConverterStageOne(int number, string expectedString)
        {
            // Ici, il aurait été pas mal d'avoir plutôt, comme demandé dans l'énoncé :
            // Assert.AreEqual(expectedString, compute(number));

            var interpreter = new NumberInterpreter(number);
            interpreter.GetExpressionByNumber();

            Assert.AreEqual(expectedString, interpreter.GetOutputExpression());
        }
    }
}
