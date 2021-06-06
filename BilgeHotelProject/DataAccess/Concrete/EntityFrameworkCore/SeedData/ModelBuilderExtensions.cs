using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duty>().HasData(
                new Duty { ID = 1, DutyName = "Resepsiyon Görevlisi", Description = "Resepsiyonda görevli personel" },
                new Duty { ID = 2, DutyName = "Temizlik Görevlisi", Description = "Temizlikten sorumlu personel" },
                new Duty { ID = 3, DutyName = "Aşçı", Description = "Mutfak Personeli" },
                new Duty { ID = 4, DutyName = "Garson", Description = "Restaurant çalışanı" },
                new Duty { ID = 5, DutyName = "Elektrikçi", Description = "Elektrik işleri sorumlusu personel" },
                new Duty { ID = 6, DutyName = "Bilgi İşlem Sorumlusu", Description = "Bilgi işlem personeli" },
                new Duty { ID = 7, DutyName = "Yönetici", Description = "Yönetici" }
                );

            modelBuilder.Entity<BookingPackage>().HasData(
                new BookingPackage { ID = 1, BookingPackageName = "Tam Pansiyon" },
                new BookingPackage { ID = 2, BookingPackageName = "Her Şey Dahil" }
                );

            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { ID = 1, RoomTypeName = "Tek Kişilik Oda", BasePrice = 200 },
                new RoomType { ID = 2, RoomTypeName = "İki Kişilik Oda", BasePrice = 300 },
                new RoomType { ID = 3, RoomTypeName = "Üç Kişilik Oda", BasePrice = 350 },
                new RoomType { ID = 4, RoomTypeName = "Dört Kişilik Oda", BasePrice = 425 },
                new RoomType { ID = 5, RoomTypeName = "Kral Dairesi", BasePrice = 500 }
                );

            modelBuilder.Entity<RoomStatus>().HasData(
                new RoomStatus { ID = 1, RoomStatusName = "Müsait" },
                new RoomStatus { ID = 2, RoomStatusName = "Dolu" },
                new RoomStatus { ID = 3, RoomStatusName = "Temizlenecek" },
                new RoomStatus { ID = 4, RoomStatusName = "Tadilatta" }
                );

            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType { ID = 1, PaymentTypeName = "Kredi Kartı" },
                new PaymentType { ID = 2, PaymentTypeName = "Banka Kartı" },
                new PaymentType { ID = 3, PaymentTypeName = "Nakit" }
                );

            modelBuilder.Entity<Room>().HasData(
                    new Room { ID = 1, RoomNumber = 110, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 2, RoomNumber = 111, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 3, RoomNumber = 112, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 4, RoomNumber = 113, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 5, RoomNumber = 114, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 6, RoomNumber = 115, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 7, RoomNumber = 116, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 8, RoomNumber = 117, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 9, RoomNumber = 118, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 10, RoomNumber = 119, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },

                    new Room { ID = 11, RoomNumber = 130, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 12, RoomNumber = 131, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 13, RoomNumber = 132, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 14, RoomNumber = 133, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 15, RoomNumber = 134, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 16, RoomNumber = 135, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 17, RoomNumber = 136, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 18, RoomNumber = 137, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 19, RoomNumber = 138, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 20, RoomNumber = 139, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 1, RoomDescription = "Üç kişilik oda", SingleBadCount = 3, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },

                    new Room { ID = 21, RoomNumber = 210, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 22, RoomNumber = 211, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 23, RoomNumber = 212, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 24, RoomNumber = 213, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 25, RoomNumber = 214, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 26, RoomNumber = 215, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 27, RoomNumber = 216, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 28, RoomNumber = 217, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 29, RoomNumber = 218, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },
                    new Room { ID = 30, RoomNumber = 219, RoomTypeId = 1, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "Tek kişilik oda", SingleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet" },

                    new Room { ID = 31, RoomNumber = 220, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 32, RoomNumber = 221, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 33, RoomNumber = 222, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 34, RoomNumber = 223, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 35, RoomNumber = 224, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 36, RoomNumber = 225, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 37, RoomNumber = 226, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 38, RoomNumber = 227, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 39, RoomNumber = 228, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },
                    new Room { ID = 40, RoomNumber = 229, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 2, RoomDescription = "İki kişilik oda", SingleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar" },

                    new Room { ID = 41, RoomNumber = 320, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 42, RoomNumber = 321, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 43, RoomNumber = 322, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 44, RoomNumber = 323, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 45, RoomNumber = 324, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 46, RoomNumber = 325, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 47, RoomNumber = 326, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 48, RoomNumber = 327, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 49, RoomNumber = 328, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 50, RoomNumber = 329, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },

                    new Room { ID = 51, RoomNumber = 330, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 52, RoomNumber = 331, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 53, RoomNumber = 332, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 54, RoomNumber = 333, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 55, RoomNumber = 334, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 56, RoomNumber = 335, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 57, RoomNumber = 336, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 58, RoomNumber = 337, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 59, RoomNumber = 338, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 60, RoomNumber = 339, RoomTypeId = 3, RoomStatusId = 1, FloorNumber = 3, RoomDescription = "Üç kişilik oda", SingleBadCount = 1, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },

                    new Room { ID = 61, RoomNumber = 420, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 62, RoomNumber = 421, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 63, RoomNumber = 422, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 64, RoomNumber = 423, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 65, RoomNumber = 424, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 66, RoomNumber = 425, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 67, RoomNumber = 426, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 68, RoomNumber = 427, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 69, RoomNumber = 428, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 70, RoomNumber = 429, RoomTypeId = 2, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "İki kişilik oda", DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },

                    new Room { ID = 71, RoomNumber = 441, RoomTypeId = 4, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Dört kişilik oda", SingleBadCount = 2, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 72, RoomNumber = 442, RoomTypeId = 4, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Dört kişilik oda", SingleBadCount = 2, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 73, RoomNumber = 443, RoomTypeId = 4, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Dört kişilik oda", SingleBadCount = 2, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 74, RoomNumber = 444, RoomTypeId = 4, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Dört kişilik oda", SingleBadCount = 2, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 75, RoomNumber = 445, RoomTypeId = 4, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Dört kişilik oda", SingleBadCount = 2, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },
                    new Room { ID = 76, RoomNumber = 446, RoomTypeId = 4, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Dört kişilik oda", SingleBadCount = 2, DoubleBadCount = 1, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" },

                    new Room { ID = 77, RoomNumber = 500, RoomTypeId = 5, RoomStatusId = 1, FloorNumber = 4, RoomDescription = "Kral Dairesi", SingleBadCount = 2, DoubleBadCount = 2, RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon" }
                );
        }
    }
}
