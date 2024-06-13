using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Factura
{
    class clsFactura
    {
        public class CreaTicket
        {
            public static StringBuilder line = new StringBuilder();
            private string ticket = "";
            private string parte1, parte2;
            public static int max = 40;
            private int cort;

            public static string LineasGuion()
            {
                return new string('-', 40);
            }

            public static void EncabezadoVenta()
            {
                line.AppendLine(" Prod          Cant   Precio    Total");
            }

            public void TextoIzquierda(string par1)
            {
                parte1 = par1.Length > 40 ? par1.Remove(40, par1.Length - 40) : par1;
                line.AppendLine(parte1);
            }

            public void TextoDerecha(string par1)
            {
                parte1 = par1.Length > 40 ? par1.Remove(40, par1.Length - 40) : par1;
                line.AppendLine(parte1.PadLeft(40));
            }

            public void TextoCentro(string par1)
            {
                parte1 = par1.Length > 40 ? par1.Remove(40, par1.Length - 40) : par1;
                int spaces = (40 - parte1.Length) / 2;
                line.AppendLine(parte1.PadLeft(spaces + parte1.Length));
            }

            public void TextoExtremos(string par1, string par2)
            {
                parte1 = par1.Length > 18 ? par1.Remove(18, par1.Length - 18) : par1;
                parte2 = par2.Length > 18 ? par2.Remove(18, par2.Length - 18) : par2;
                int spaces = 40 - (parte1.Length + parte2.Length);
                line.AppendLine(parte1 + new string(' ', spaces) + parte2);
            }

            public void AgregaTotales(string par1, double total)
            {
                parte1 = par1.Length > 25 ? par1.Remove(25, par1.Length - 25) : par1;
                parte2 = total.ToString("C");
                int spaces = 40 - (parte1.Length + parte2.Length);
                line.AppendLine(parte1 + new string(' ', spaces) + parte2);
            }

            public void AgregaArticulo(string articulo, double precio, int cant, double subtotal)
            {
                if (cant.ToString().Length > 3 || precio.ToString("C").Length > 10 || subtotal.ToString("C").Length > 11)
                {
                    // Valores fuera de rango
                    throw new ArgumentOutOfRangeException("Valores fuera de rango.");
                }

                string elementos = $"{cant.ToString().PadLeft(3)}{precio.ToString().PadLeft(10)}{subtotal.ToString().PadLeft(11)}";
                if (articulo.Length > 40)
                {
                    int charActual = 0;
                    bool firstLine = true;
                    while (charActual < articulo.Length)
                    {
                        int length = Math.Min(16, articulo.Length - charActual);
                        if (firstLine)
                        {
                            line.AppendLine(articulo.Substring(charActual, length) + elementos);
                            firstLine = false;
                        }
                        else
                        {
                            line.AppendLine(articulo.Substring(charActual, length));
                        }
                        charActual += length;
                    }
                }
                else
                {
                    string espacios = new string(' ', 16 - articulo.Length);
                    line.AppendLine(articulo + espacios + elementos);
                }
            }

            public bool ValidarPago(double total, double pago)
            {
                if (pago < total)
                {
                    MessageBox.Show("El monto ingresado es menor a la cantidad a pagar.");
                    return false;
                }
                return true;
            }


            public void ImprimirTiket(string impresora, double total, double pago)
            {
                if (pago < total)
                {
                    Console.WriteLine("El monto ingresado es menor a la cantidad a pagar.");
                    return;
                }

                RawPrinterHelper.SendStringToPrinter(impresora, line.ToString());
                line.Clear();
            }

        }

        #region Clase para enviar a impresora texto plano
        public class RawPrinterHelper
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }

            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
            {
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA
                {
                    pDocName = "My C#.NET RAW Document",
                    pDataType = "RAW"
                };

                bool bSuccess = false;

                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        if (StartPagePrinter(hPrinter))
                        {
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out int dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }

                if (!bSuccess)
                {
                    int dwError = Marshal.GetLastWin32Error();
                    // Manejo del error según sea necesario
                }
                return bSuccess;
            }

            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                int dwCount = szString.Length;
                IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                bool result = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return result;
            }
        }
        #endregion
    }
}

