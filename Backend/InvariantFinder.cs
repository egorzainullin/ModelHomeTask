using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using FSharpBackend;

namespace Backend
{
    public class InvariantFinder
    {
        private readonly FSharpFinder _fSharpFinder;
        
        /// <summary>
        /// Instantiates new <see cref="InvariantFinder"/>
        /// </summary>
        /// <param name="minVal">Minimal</param>
        /// <param name="maxVal">maximal</param>
        /// <param name="z0">Initial value</param>
        /// <param name="c">Parameter</param>
        public InvariantFinder(double minVal, double maxVal, Complex z0, Complex c) 
        {
            _fSharpFinder = new FSharpFinder(minVal, maxVal, z0, c);
        }
        
        public (List<Complex>, List<Complex>) DoProcessing()
        {
            var (inList, outList) = _fSharpFinder.Process();
            return (inList, outList);
        }

        public static (List<Double>, List<double>)UnzipComplexList(List<Complex> list)
        {
            var (xs, ys) = FSharpFinder.UnzipComplexListIntoTwo(list);
            return (xs, ys);
        }
    }
}
