//-----------------------------------------------------------------------------
// <copyright file="DistributionTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DistributionTests
    {
        private const int RUNS = 1000;

        [TestMethod]
        public void InvertedDistribution()
        {
            var classifications = this.Classify(Distribution.InvertedNormal);
            Specify.Aggregate(delegate
            {
                Specify.That(classifications.LessThan0.Percent).Should.BeEqualTo(0);
                Specify.That(classifications.LessThan15Hundredths.Percent > .27).Should.BeTrue();
                Specify.That(classifications.GreaterThan85Hundredths.Percent > .27).Should.BeTrue();
            });
        }

        [TestMethod]
        public void NegativeDistribution()
        {
            var classifications = this.Classify(Distribution.NegativeNormal);
            Specify.Aggregate(delegate
            {
                Specify.That(classifications.LessThan0.Percent).Should.BeEqualTo(0);
                Specify.That(classifications.LessThan15Hundredths.Percent < .02).Should.BeTrue();
                Specify.That(classifications.GreaterThan85Hundredths.Percent > .25).Should.BeTrue();
            });
        }

        [TestMethod]
        public void PositiveDistribution()
        {
            var classifications = this.Classify(Distribution.PositiveNormal);
            Specify.Aggregate(delegate
            {
                Specify.That(classifications.LessThan0.Percent).Should.BeEqualTo(0);
                Specify.That(classifications.LessThan15Hundredths.Percent > .25).Should.BeTrue();
                Specify.That(classifications.GreaterThan85Hundredths.Percent < .02).Should.BeTrue();
            });
        }

        private DistributionClassifier Classify(Distribution distribution)
        {
            var classifier = new DistributionClassifier();

            Random random = new Random(0x73577357);
            for (int i = 0; i < RUNS; ++i)
            {
                classifier.Classify(distribution.NextDouble(random));
            }

            return classifier;
        }

        private class DistributionClassifier : Classifier<double>
        {
            public DistributionClassifier()
            {
                this.LessThan15Hundredths = this.CreateClassification(d => d < .15);
                this.GreaterThan85Hundredths = this.CreateClassification(d => d > .85);
                this.LessThan0 = this.CreateClassification(d => d < 0);
                this.GreaterThan0 = this.CreateClassification(d => d > 0);
            }

            public Classification GreaterThan0 { get; private set; }

            public Classification GreaterThan85Hundredths { get; private set; }

            public Classification LessThan0 { get; private set; }

            public Classification LessThan15Hundredths { get; private set; }
        }
    }
}