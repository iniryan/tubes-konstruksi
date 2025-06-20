using Xunit;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class StatusTransisiTests
    {
        [Fact]
        public void Should_Allow_Transition_From_Dibuat_To_Diproses()
        {
            var result = StatusTransisi.BisaTransisi(StatusPengaduan.Dibuat, StatusPengaduan.Diproses);

            Assert.True(result);
        }

        [Fact]
        public void Should_Allow_Transition_From_Dibuat_To_Ditolak()
        {
            var result = StatusTransisi.BisaTransisi(StatusPengaduan.Dibuat, StatusPengaduan.Ditolak);

            Assert.True(result);
        }

        [Fact]
        public void Should_Allow_Transition_From_Diproses_To_Selesai()
        {
            var result = StatusTransisi.BisaTransisi(StatusPengaduan.Diproses, StatusPengaduan.Selesai);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Allow_Transition_From_Dibuat_To_Selesai()
        {
            var result = StatusTransisi.BisaTransisi(StatusPengaduan.Dibuat, StatusPengaduan.Selesai);

            Assert.False(result);
        }

        [Fact]
        public void Should_Not_Allow_Transition_From_Diproses_To_Ditolak()
        {
            var result = StatusTransisi.BisaTransisi(StatusPengaduan.Diproses, StatusPengaduan.Ditolak);

            Assert.False(result);
        }

        [Fact]
        public void Should_Not_Allow_Transition_From_Selesai_To_Any_Status()
        {
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Selesai, StatusPengaduan.Dibuat));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Selesai, StatusPengaduan.Diproses));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Selesai, StatusPengaduan.Ditolak));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Selesai, StatusPengaduan.Selesai));
        }

        [Fact]
        public void Should_Not_Allow_Transition_From_Ditolak_To_Any_Status()
        {
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Ditolak, StatusPengaduan.Dibuat));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Ditolak, StatusPengaduan.Diproses));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Ditolak, StatusPengaduan.Selesai));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Ditolak, StatusPengaduan.Ditolak));
        }

        [Fact]
        public void Should_Not_Allow_Same_Status_Transitions()
        {
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Dibuat, StatusPengaduan.Dibuat));
            Assert.False(StatusTransisi.BisaTransisi(StatusPengaduan.Diproses, StatusPengaduan.Diproses));
        }

        [Theory]
        [InlineData(StatusPengaduan.Dibuat, StatusPengaduan.Diproses, true)]
        [InlineData(StatusPengaduan.Dibuat, StatusPengaduan.Ditolak, true)]
        [InlineData(StatusPengaduan.Diproses, StatusPengaduan.Selesai, true)]
        [InlineData(StatusPengaduan.Dibuat, StatusPengaduan.Selesai, false)]
        [InlineData(StatusPengaduan.Diproses, StatusPengaduan.Ditolak, false)]
        [InlineData(StatusPengaduan.Selesai, StatusPengaduan.Dibuat, false)]
        [InlineData(StatusPengaduan.Ditolak, StatusPengaduan.Diproses, false)]
        public void Should_Validate_Status_Transitions_Correctly(StatusPengaduan dari, StatusPengaduan ke, bool expected)
        {
            var result = StatusTransisi.BisaTransisi(dari, ke);

            Assert.Equal(expected, result);
        }
    }
}
