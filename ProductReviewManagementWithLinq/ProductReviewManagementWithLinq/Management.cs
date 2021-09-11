using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace ProductReviewManagementWithLinq
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();

        //UC2
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordData = (from productReviews in listProductReview
                              orderby productReviews.Rating descending
                              select productReviews).Take(3);
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID:- " + list.ProductID + " UserID:- " + list.UserID + " Rating:- " + list.Rating + " Review:- " + list.Review + " isLike:- " + list.isLike);
            }
        }


        //UC3
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordData =  from productReviews in listProductReview
                              where (productReviews.ProductID == 1 || productReviews.ProductID == 4 || productReviews.ProductID == 9)
                              && (productReviews.Rating > 3)
                              select productReviews;

            //(productReviews.ProductID == 1 && productReviews.ProductID > 3) ||
            //(productReviews.ProductID == 4 && productReviews.ProductID > 3) ||
            //(productReviews.ProductID == 9 && productReviews.ProductID > 3) 

            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID:- " + list.ProductID + " UserID:- " + list.UserID + " Rating:- " + list.Rating + " Review:- " + list.Review + " isLike:- " + list.isLike);
            }

        }

        //UC4
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductID + "---------"+list.Count);
            }
        }
    }
}
