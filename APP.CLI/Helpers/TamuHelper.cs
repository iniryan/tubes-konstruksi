using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GuestApp.Models;

namespace GuestApp.Helpers
{
    public static class TamuHelper
    {
        public static List<Tamu> CariTamu(List<Tamu> tamuList, string keyword)
        {
            return tamuList.Where(t =>
                t.Nama.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                t.WaktuDatang.ToString("yyyy-MM-dd").Contains(keyword)
            ).ToList();
        }

        public static int HitungHarian(List<Tamu> tamuList)
        {
            return tamuList.Count(t => t.WaktuDatang.Date == DateTime.Today);
        }
    }
}

