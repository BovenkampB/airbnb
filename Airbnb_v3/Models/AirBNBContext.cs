using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Airbnb_v3.Models
{
    public partial class AirBNBContext : DbContext
    {
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Listings> Listings { get; set; }
        public virtual DbSet<Neighbourhoods> Neighbourhoods { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SummaryListings> SummaryListings { get; set; }
        public virtual DbSet<SummaryReviews> SummaryReviews { get; set; }
        public virtual DbSet<SmallListings> SmallListings { get; set; }

        //Constructor which allows configuration to be passed into the context by DI
        public AirBNBContext(DbContextOptions<AirBNBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.HasKey(e => new { e.ListingId, e.Date });

                entity.ToTable("calendar");

                entity.Property(e => e.ListingId).HasColumnName("listing_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasColumnName("available")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Calendar)
                    .HasForeignKey(d => d.ListingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_calendar_listings");
            });

            modelBuilder.Entity<SmallListings>(entity =>
            {
                entity.ToTable("Listings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");

                entity.Property(e => e.Neighbourhood).HasColumnName("neighbourhood");

                entity.Property(e => e.ReviewScoresRating).HasColumnName("review_scores_rating");

            });

            modelBuilder.Entity<Listings>(entity =>
            {
                entity.ToTable("listings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Access)
                    .IsRequired()
                    .HasColumnName("access");

                entity.Property(e => e.Accommodates).HasColumnName("accommodates");

                entity.Property(e => e.Amenities).HasColumnName("amenities");

                entity.Property(e => e.Availability30).HasColumnName("availability_30");

                entity.Property(e => e.Availability365).HasColumnName("availability_365");

                entity.Property(e => e.Availability60).HasColumnName("availability_60");

                entity.Property(e => e.Availability90).HasColumnName("availability_90");

                entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");

                entity.Property(e => e.BedType).HasColumnName("bed_type");

                entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");

                entity.Property(e => e.Beds).HasColumnName("beds");

                entity.Property(e => e.CalculatedHostListingsCount).HasColumnName("calculated_host_listings_count");

                entity.Property(e => e.CalendarLastScraped).HasColumnName("calendar_last_scraped");

                entity.Property(e => e.CalendarUpdated).HasColumnName("calendar_updated");

                entity.Property(e => e.CancellationPolicy)
                    .IsRequired()
                    .HasColumnName("cancellation_policy");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CleaningFee).HasColumnName("cleaning_fee");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.ExperiencesOffered)
                    .IsRequired()
                    .HasColumnName("experiences_offered");

                entity.Property(e => e.ExtraPeople).HasColumnName("extra_people");

                entity.Property(e => e.FirstReview).HasColumnName("first_review");

                entity.Property(e => e.GuestsIncluded).HasColumnName("guests_included");

                entity.Property(e => e.HasAvailability).HasColumnName("has_availability");

                entity.Property(e => e.HostAbout).HasColumnName("host_about");

                entity.Property(e => e.HostAcceptanceRate).HasColumnName("host_acceptance_rate");

                entity.Property(e => e.HostHasProfilePic).HasColumnName("host_has_profile_pic");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.HostIdentityVerified).HasColumnName("host_identity_verified");

                entity.Property(e => e.HostIsSuperhost).HasColumnName("host_is_superhost");

                entity.Property(e => e.HostListingsCount).HasColumnName("host_listings_count");

                entity.Property(e => e.HostLocation).HasColumnName("host_location");

                entity.Property(e => e.HostName).HasColumnName("host_name");

                entity.Property(e => e.HostNeighbourhood).HasColumnName("host_neighbourhood");

                entity.Property(e => e.HostPictureUrl).HasColumnName("host_picture_url");

                entity.Property(e => e.HostResponseRate).HasColumnName("host_response_rate");

                entity.Property(e => e.HostResponseTime).HasColumnName("host_response_time");

                entity.Property(e => e.HostSince).HasColumnName("host_since");

                entity.Property(e => e.HostThumbnailUrl).HasColumnName("host_thumbnail_url");

                entity.Property(e => e.HostTotalListingsCount).HasColumnName("host_total_listings_count");

                entity.Property(e => e.HostUrl)
                    .IsRequired()
                    .HasColumnName("host_url");

                entity.Property(e => e.HostVerifications).HasColumnName("host_verifications");

                entity.Property(e => e.HouseRules)
                    .IsRequired()
                    .HasColumnName("house_rules");

                entity.Property(e => e.InstantBookable)
                    .IsRequired()
                    .HasColumnName("instant_bookable");

                entity.Property(e => e.Interaction)
                    .IsRequired()
                    .HasColumnName("interaction");

                entity.Property(e => e.IsBusinessTravelReady)
                    .IsRequired()
                    .HasColumnName("is_business_travel_ready");

                entity.Property(e => e.IsLocationExact).HasColumnName("is_location_exact");

                entity.Property(e => e.JurisdictionNames).HasColumnName("jurisdiction_names");

                entity.Property(e => e.LastReview).HasColumnName("last_review");

                entity.Property(e => e.LastScraped).HasColumnName("last_scraped");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.License).HasColumnName("license");

                entity.Property(e => e.ListingUrl)
                    .IsRequired()
                    .HasColumnName("listing_url");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Market).HasColumnName("market");

                entity.Property(e => e.MaximumNights).HasColumnName("maximum_nights");

                entity.Property(e => e.MediumUrl).HasColumnName("medium_url");

                entity.Property(e => e.MinimumNights).HasColumnName("minimum_nights");

                entity.Property(e => e.MonthlyPrice).HasColumnName("monthly_price");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.NeighborhoodOverview)
                    .IsRequired()
                    .HasColumnName("neighborhood_overview");

                entity.Property(e => e.Neighbourhood).HasColumnName("neighbourhood");

                entity.Property(e => e.NeighbourhoodCleansed).HasColumnName("neighbourhood_cleansed");

                entity.Property(e => e.NeighbourhoodGroupCleansed).HasColumnName("neighbourhood_group_cleansed");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes");

                entity.Property(e => e.NumberOfReviews).HasColumnName("number_of_reviews");

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasColumnName("picture_url");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PropertyType).HasColumnName("property_type");

                entity.Property(e => e.RequireGuestPhoneVerification)
                    .IsRequired()
                    .HasColumnName("require_guest_phone_verification");

                entity.Property(e => e.RequireGuestProfilePicture)
                    .IsRequired()
                    .HasColumnName("require_guest_profile_picture");

                entity.Property(e => e.RequiresLicense)
                    .IsRequired()
                    .HasColumnName("requires_license");

                entity.Property(e => e.ReviewScoresAccuracy).HasColumnName("review_scores_accuracy");

                entity.Property(e => e.ReviewScoresCheckin).HasColumnName("review_scores_checkin");

                entity.Property(e => e.ReviewScoresCleanliness).HasColumnName("review_scores_cleanliness");

                entity.Property(e => e.ReviewScoresCommunication).HasColumnName("review_scores_communication");

                entity.Property(e => e.ReviewScoresLocation).HasColumnName("review_scores_location");

                entity.Property(e => e.ReviewScoresRating).HasColumnName("review_scores_rating");

                entity.Property(e => e.ReviewScoresValue).HasColumnName("review_scores_value");

                entity.Property(e => e.ReviewsPerMonth).HasColumnName("reviews_per_month");

                entity.Property(e => e.RoomType).HasColumnName("room_type");

                entity.Property(e => e.ScrapeId).HasColumnName("scrape_id");

                entity.Property(e => e.SecurityDeposit).HasColumnName("security_deposit");

                entity.Property(e => e.SmartLocation).HasColumnName("smart_location");

                entity.Property(e => e.Space)
                    .IsRequired()
                    .HasColumnName("space");

                entity.Property(e => e.SquareFeet).HasColumnName("square_feet");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnName("summary");

                entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");

                entity.Property(e => e.Transit)
                    .IsRequired()
                    .HasColumnName("transit");

                entity.Property(e => e.WeeklyPrice).HasColumnName("weekly_price");

                entity.Property(e => e.XlPictureUrl).HasColumnName("xl_picture_url");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<Listings>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_listings_listings");
            });

            modelBuilder.Entity<Neighbourhoods>(entity =>
            {
                entity.HasKey(e => e.Neighbourhood);

                entity.ToTable("neighbourhoods");

                entity.Property(e => e.Neighbourhood)
                    .HasColumnName("neighbourhood")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.NeighbourhoodGroup)
                    .HasColumnName("neighbourhood_group")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.ListingId).HasColumnName("listing_id");

                entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasColumnName("reviewer_name")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Listing)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ListingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviews_listings");
            });

            modelBuilder.Entity<SummaryListings>(entity =>
            {
                entity.ToTable("summary-listings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Availability365).HasColumnName("availability_365");

                entity.Property(e => e.CalculatedHostListingsCount).HasColumnName("calculated_host_listings_count");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.HostName).HasColumnName("host_name");

                entity.Property(e => e.LastReview).HasColumnName("last_review");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.MinimumNights).HasColumnName("minimum_nights");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Neighbourhood).HasColumnName("neighbourhood");

                entity.Property(e => e.NeighbourhoodGroup)
                    .HasColumnName("neighbourhood_group")
                    .HasMaxLength(1);

                entity.Property(e => e.NumberOfReviews).HasColumnName("number_of_reviews");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ReviewsPerMonth).HasColumnName("reviews_per_month");

                entity.Property(e => e.RoomType).HasColumnName("room_type");
            });

            modelBuilder.Entity<SummaryReviews>(entity =>
            {
                entity.HasKey(e => new { e.ListingId, e.Date });

                entity.ToTable("summary-reviews");

                entity.Property(e => e.ListingId).HasColumnName("listing_id");

                entity.Property(e => e.Date).HasColumnName("date");
            });
        }
    }
}
