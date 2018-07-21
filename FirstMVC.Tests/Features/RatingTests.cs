using System;
using System.Collections.Generic;
using System.Linq;
using FirstMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstMVC.Tests.Features
{
    [TestClass]
    public class RatingTests
    {
        [TestMethod]
        public void Computes_Result_For_One_Review()
        {
            var data = BuildCarAndReviews(ratings: new[] { 4 });

            var rater = new CarRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void Computes_Result_For_Two_Review()
        {
            var data = BuildCarAndReviews(ratings: new[] { 4, 8 });

            var rater = new CarRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Weighted_Averging_For_Two_Reviews()
        {
            var data = BuildCarAndReviews(ratings: new[] { 3, 9 });

            var rater = new CarRater(data);
            var result = rater.ComputeResult(new WeightedRatingAlgorithm(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        [TestMethod]
        public void Rating_Includes_Only_First_N_Reviews()
        {
            var data = BuildCarAndReviews(1, 1, 1, 10, 10, 10);

            var rater = new CarRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 3);

            Assert.AreEqual(1, result.Rating);
        }

        private Cars BuildCarAndReviews(params int[] ratings)
        {
            var car = new Cars();

            //need a using statement for System.Linq at the top of the file

            car.Reviews =
                ratings.Select(r => new CarReviews { Rating = r })
                .ToList();
            return car;
        }
    }
}
