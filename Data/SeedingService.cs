﻿using SistemaDeVendasWeb.Models;
using SistemaDeVendasWeb.Models.Enuns;

namespace SistemaDeVendasWeb.Data
{
    public class SeedingService
    {
        private SistemaDeVendasWebContext _context;

        public SeedingService(SistemaDeVendasWebContext context)
        {
            _context = context;
        }

        // Método auxiliar para criar DateTime em UTC  
        private DateTime Utc(int year, int month, int day)
        {
            return new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has been seeded  
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller( 1,"Bob Brown", "bob@gmail.com", Utc(1998, 4, 21), 10000, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", Utc(1979, 12, 31), 35000, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", Utc(1988, 1, 15), 2200, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", Utc(1993, 11, 30), 3000, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", Utc(2000, 1, 9), 4000, d3);
            Seller s6 = new Seller(6, "Alex Pink", "alexpink@gmail.com", Utc(1997, 3, 4), 3000, d2);

            SalesRecord r1 = new SalesRecord(1, Utc(2018, 09, 25), 11000, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, Utc(2018, 09, 4), 7000, SaleStatus.Billed, s5);
            SalesRecord r3 = new SalesRecord(3, Utc(2018, 09, 13), 4000, SaleStatus.Canceled, s4);
            SalesRecord r4 = new SalesRecord(4, Utc(2018, 09, 1), 8000, SaleStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(5, Utc(2018, 09, 21), 3000, SaleStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(6, Utc(2018, 09, 15), 2000, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(7, Utc(2018, 09, 28), 13000, SaleStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(8, Utc(2018, 09, 11), 4000, SaleStatus.Billed, s4);
            SalesRecord r9 = new SalesRecord(9, Utc(2018, 09, 14), 11000, SaleStatus.Pending, s6);
            SalesRecord r10 = new SalesRecord(10, Utc(2018, 09, 7), 9000, SaleStatus.Billed, s6);
            SalesRecord r11 = new SalesRecord(11, Utc(2018, 09, 13), 6000, SaleStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(12, Utc(2018, 09, 25), 7000, SaleStatus.Pending, s3);
            SalesRecord r13 = new SalesRecord(13, Utc(2018, 09, 29), 10000, SaleStatus.Billed, s4);
            SalesRecord r14 = new SalesRecord(14, Utc(2018, 09, 4), 3000, SaleStatus.Billed, s5);
            SalesRecord r15 = new SalesRecord(15, Utc(2018, 09, 12), 4000, SaleStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(16, Utc(2018, 10, 5), 2000, SaleStatus.Billed, s4);
            SalesRecord r17 = new SalesRecord(17, Utc(2018, 10, 1), 12000, SaleStatus.Billed, s1);
            SalesRecord r18 = new SalesRecord(18, Utc(2018, 10, 24), 6000, SaleStatus.Billed, s3);
            SalesRecord r19 = new SalesRecord(19, Utc(2018, 10, 22), 8000, SaleStatus.Billed, s5);
            SalesRecord r20 = new SalesRecord(20, Utc(2018, 10, 15), 8000, SaleStatus.Billed, s6);
            SalesRecord r21 = new SalesRecord(21, Utc(2018, 10, 17), 9000, SaleStatus.Billed, s2);
            SalesRecord r22 = new SalesRecord(22, Utc(2018, 10, 24), 4000, SaleStatus.Billed, s4);
            SalesRecord r23 = new SalesRecord(23, Utc(2018, 10, 19), 11000, SaleStatus.Canceled, s2);
            SalesRecord r24 = new SalesRecord(24, Utc(2018, 10, 12), 8000, SaleStatus.Billed, s5);
            SalesRecord r25 = new SalesRecord(25, Utc(2018, 10, 31), 7000, SaleStatus.Billed, s3);
            SalesRecord r26 = new SalesRecord(26, Utc(2018, 10, 6), 5000, SaleStatus.Billed, s4);
            SalesRecord r27 = new SalesRecord(27, Utc(2018, 10, 13), 9000, SaleStatus.Pending, s1);
            SalesRecord r28 = new SalesRecord(28, Utc(2018, 10, 7), 4000, SaleStatus.Billed, s3);
            SalesRecord r29 = new SalesRecord(29, Utc(2018, 10, 23), 12000, SaleStatus.Billed, s5);
            SalesRecord r30 = new SalesRecord(30, Utc(2018, 10, 12), 5000, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}