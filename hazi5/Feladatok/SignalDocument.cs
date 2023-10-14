using Signals.DocView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class SignalDocument : Document
    {
        private List<SignalValue> signals = new List<SignalValue>();

        private SignalValue[] testValues = new SignalValue[]
        {
            new SignalValue(31, new DateTime(2023, 3, 14, 0, 0, 0, 333)),
            new SignalValue(14, new DateTime(2023, 3, 14, 0, 0, 0, 656)),
            new SignalValue(-66, new DateTime(2023, 3, 14, 0, 0, 1, 199)),
            new SignalValue(12, new DateTime(2023, 3, 14, 0, 0, 2, 531)),
            new SignalValue(68, new DateTime(2023, 3, 14, 0, 0, 3, 674)),
            new SignalValue(-33, new DateTime(2023, 3, 14, 0, 0, 4, 831)),
        };

        public SignalDocument(string name)
            : base(name)
        {
            // Kezdetben dolgozzunk úgy, hogy a signals
            // jelérték listát a testValues alapján inicializáljuk.
            signals.AddRange(testValues);
        }

        public override void SaveDocument(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (SignalValue signalValue in signals)
                {
                    var dt = signalValue.TimeStamp.ToUniversalTime().ToString("O");
                    sw.WriteLine($"{signalValue.Value}\t{dt}");
                }
            }
        }

        public override void LoadDocument(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                signals.Clear();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line.Trim();
                    string[] columns = line.Split('\t');
                    double d = double.Parse(columns[0]);
                    DateTime dt = DateTime.Parse(columns[1]);
                    DateTime localDt = dt.ToLocalTime();

                    signals.Add(new SignalValue(d, localDt));
                }
            }
            TraceValues();
        }

        private void TraceValues()
        {
            foreach (var signal in signals)
                Trace.WriteLine(signal.ToString());
        }

        public IReadOnlyList<SignalValue> Signals
        {
            get { return signals; }
        }
    }
}
