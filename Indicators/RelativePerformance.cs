//
// RelativePerformance.cs
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
   /// Berechnet die relative Veraenderung jedes Einzelwertes zum ersten
   /// Element der Datenreihe in dB%.
   /// </summary>
   ///
   /// Dazu wird der Quotient aus jedem Element mit dem ersten Wert gebildet,
   /// logarithmiert und mit 100 multipliziert. Durch Verwendung des
   /// Logarithmus zur Basis 2 resultiert aus einem Veraenderungsfaktor
   /// von 2 (sprich Verdoppelung) ein dB%-Wert von 100.
   /// Eine Halbierung entspricht einem dB%-Wert von -100.
   ///
   /// RelativePerformance wird wie folgt berechnet: Log_2
   /// \f[
   ///  x_r = \log{\frac{x_n}{x_(0)}}
   /// \f]
   public class RelativePerformance
   {
      /// <summary>
      /// Berechnet die relative Veraenderung jedes Einzelwertes
      /// zum ersten Element der Datenreihe in dB%.
      /// </summary>
      ///
      /// <param name="source">Daten, von denen die relativen Veraenderungen gebildet werden sollen</param>
      /// <returns>Neuer DatenContainer mit den Ergebnisdaten</returns>
      public static DataContainer CreateFrom(DataContainer source)
      {
         return CreateFrom(source, source.OldestDate);
      }

      public static DataContainer CreateFrom(DataContainer source, WorkDate referenceDate)
      {
         DataContainer result = new DataContainer();
         WorkDate workdate = source.OldestDate.Clone();
         double dReference = source[referenceDate];

         for (; workdate <= source.YoungestDate; workdate++)
         {
            result[workdate] = Math.Log(source[workdate] / dReference, 2.0) * 100.0;
            //result[workdate] = ((source[workdate] / dReference) - 1.0) * 100.0;
         }

         return result;
      }

   }
}
