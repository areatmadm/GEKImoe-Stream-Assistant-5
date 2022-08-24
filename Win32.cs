using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AreaTM_acbas
{
    public class Win32
    {
        #region 사운드 관련
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static void SetSoundVolume(int volume)
        {
            try
            {
                int newVolume = ((ushort.MaxValue / 10) * volume);
                uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));
                waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);
            }
            catch (Exception) { }
        }

        public static int GetSoundVolume()
        {
            int value = 0;
            try
            {
                uint CurrVol = 0;
                waveOutGetVolume(IntPtr.Zero, out CurrVol);
                ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
                value = CalcVol / (ushort.MaxValue / 10);
            }
            catch (Exception) { }
            return value;
        }
        #endregion
    }
}
