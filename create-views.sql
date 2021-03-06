
CREATE View AantalReviewsPerYear as 
SELECT [listing_id]
      ,YEAR(date) as jaar, count(YEAR(date) )as aantalReviews
  FROM [AirBNB].[dbo].[summary-reviews]
   
  GROUP BY listing_id, year(date)



CREATE VIEW review_per_neighbourhood AS
SELECT [neighbourhood_cleansed], AVG([review_scores_rating]) as review
  FROM AirBNB.[dbo].[Listings]
  GROUP BY neighbourhood_cleansed
GO

CREATE VIEW price_per_neighbourhood AS
SELECT neighbourhood, AVG(Price) as price
FROM [summary-listings]
GROUP BY neighbourhood