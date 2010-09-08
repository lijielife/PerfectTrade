//
// FixedGrowthInvestment.cs
//
// COPYRIGHT (C) 2010 AND ALL RIGHTS RESERVED BY
// MARC WEIDLER, ULRICHSTR. 12/1, 71672 MARBACH, GERMANY (MARC.WEIDLER@WEB.DE).
//
// ALL RIGHTS RESERVED. THIS SOFTWARE AND RELATED DOCUMENTATION ARE PROTECTED BY
// COPYRIGHT RESTRICTING ITS USE, COPYING, DISTRIBUTION, AND DECOMPILATION. NO PART
// OF THIS PRODUCT OR RELATED DOCUMENTATION MAY BE REPRODUCED IN ANY FORM BY ANY
// MEANS WITHOUT PRIOR WRITTEN AUTHORIZATION OF MARC WEIDLER OR HIS PARTNERS, IF ANY.
// UNLESS OTHERWISE ARRANGED, THIRD PARTIES MAY NOT HAVE ACCESS TO THIS PRODUCT OR
// RELATED DOCUMENTATION. SEE LICENSE FILE FOR DETAILS.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
// OF THE POSSIBILITY OF SUCH DAMAGE. THE ENTIRE RISK AS TO THE QUALITY AND
// PERFORMANCE OF THE PROGRAM IS WITH YOU. SHOULD THE PROGRAM PROVE DEFECTIVE,
// YOU ASSUME THE COST OF ALL NECESSARY SERVICING, REPAIR OR CORRECTION.
//

using System;
using System.Collections.Generic;
using System.Text;
using FinancialObjects;

namespace Indicators
{
    /// <summary>
    /// Berechnet eine Performance-Entwicklung einer festverzinslichen Anlage
    /// im angegebenen Zeitraum und mit dem gewuenschten Zinssatz.
    /// </summary>
    public class FixedGrowthInvestment
    {
        /// <summary>
        /// Fuehrt eine Zinseszinsberechnung auf der Basis des angegebenen
        /// Prozentsatzes und einem Startkapital von 100.0 aus.
        /// Die Berechnung wird f�r jeden Arbeitstag (und Feiertage), jedoch
        /// nicht fuer Wochenenden durchgefuehrt.
        /// </summary>
        /// <param name="fromDate">Beginn des Berechnungszeitraumes</param>
        /// <param name="toDate">Ende des Berechnungszeitraumes</param>
        /// <param name="dYearGrowth">Jahres-Performance in Prozent, z.B. 3.45</param>
        public static DataContainer CreateFrom(WorkDate fromDate, WorkDate toDate, double dYearGrowth)
        {
            DataContainer result = new DataContainer();

            dYearGrowth /= 100.0;
            double dPerformanceFactor = Math.Pow(1.0 + dYearGrowth, 1.0 / WorkDate.WorkDaysPerYear);
            double dEquity = 100.0;

            for (WorkDate workdate = fromDate.Clone(); workdate <= toDate; workdate++)
            {
                result[workdate] = dEquity;
                dEquity *= dPerformanceFactor;
            }

            return result;
        }
    }
}
