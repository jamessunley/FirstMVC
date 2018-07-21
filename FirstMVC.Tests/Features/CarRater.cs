using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMVC.Models;

namespace FirstMVC.Tests.Features
{
    public class CarRater
    {
        private Cars _car;

        public CarRater(Cars car)
        {
            this._car = car;
        }

        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfReviewsToUse)
        {
            var filteredReviews = _car.Reviews.Take(numberOfReviewsToUse);
            return algorithm.Compute(filteredReviews.ToList());
        }
        //public RatingResult ComputeRating(int v)
        //{
        //    var result = new RatingResult();
        //    result.Rating = (int)_car.Reviews.Average(r => r.Rating);
        //    return result;
        //}

        //public RatingResult ComputeWeightedRate(int numberOfReviews)
        //{
        //    var reviews = _car.Reviews.ToArray();
        //    var result = new RatingResult();
        //    var counter = 0;
        //    var total = 0;

        //    for (int i = 0; i < reviews.Count(); i++)
        //    {
        //        if(i < reviews.Count() / 2)
        //        {
        //            counter += 2;
        //            total += reviews[i].Rating * 2;
        //        }
        //        else
        //        {
        //            counter += 1;
        //            total += reviews[i].Rating;
        //        }
        //    }

        //    result.Rating = total / counter;
        //    return result;
        //}
    }
}
