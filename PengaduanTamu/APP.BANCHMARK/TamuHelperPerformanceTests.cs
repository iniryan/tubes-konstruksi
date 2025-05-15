using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using GuestApp.Helpers;
using GuestApp.Models;
using System;
using System.Collections.Generic;

namespace APP.TESTING
{
    public class TamuHelperPerformanceTests
    {
        private List<Tamu> tamuList;

        [GlobalSetup]
        public void Setup()
        {
            tamuList = new List<Tamu>();
            for (int i = 0; i < 10000; i++)
            {
                tamuList.Add(new Tamu
                {
                    Id = i + 1,
                    Nama = "Tamu" + i,
                    WaktuDatang = DateTime.Today.AddDays(-(i % 10))
                });
            }
        }

        [Benchmark]
        public List<Tamu> TestCariTamu()
        {
            return TamuHelper.CariTamu(tamuList, "Tamu999");
        }

        [Benchmark]
        public int TestHitungHarian()
        {
            return TamuHelper.HitungHarian(tamuList);
        }
    }
}
