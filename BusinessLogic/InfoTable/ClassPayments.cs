using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InfoTable
{
    public class ClassPayments
    {
        public int PaymentID { get; set; }

        public ClassVisit VisitInfo { get; set; }

        public double Amount { get; set; }

        public double Discount { get; set; }

        public double TotalAmount { get; set; }

        public string PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Notes { get; set; }

        public int CreateBy { get; set; }








        /// <summary>
        /// جلب معلومات دفعة كاملة مع معلومات الزيارة المرتبطة بها
        /// </summary>
        public static ClassPayments GetPaymentById(int paymentId)
        {
            string query = @"
        SELECT TOP 1
            PaymentId,
            PersonId,
            VisitId,
            AppointmentId,
            Amount,
            Discount,
            TotalAmount,
            PaymentMethod,
            PaymentDate,
            Notes,
            CreatedBy
        FROM Payments
        WHERE PaymentId = @PaymentId
    ";

            var parameters = new Dictionary<string, object>
            {
                { "@PaymentId", paymentId }
            };

            DataTable dt = ClassCommands.ShowData(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            // تعبئة كائن الدفعة
            ClassPayments payment = new ClassPayments()
            {
                PaymentID = Convert.ToInt32(row["PaymentId"]),
                Amount = Convert.ToDouble(row["Amount"]),
                Discount = Convert.ToDouble(row["Discount"]),
                TotalAmount = Convert.ToDouble(row["TotalAmount"]),
                PaymentType = row["PaymentMethod"].ToString(),
                PaymentDate = Convert.ToDateTime(row["PaymentDate"]),
                Notes = row["Notes"]?.ToString(),
                CreateBy = Convert.ToInt32(row["CreatedBy"])
            };

            // جلب معلومات الزيارة إذا كانت موجودة
            if (row["VisitId"] != DBNull.Value)
            {
                int visitId = Convert.ToInt32(row["VisitId"]);
                payment.VisitInfo = ClassVisit.GetVisitById(visitId);
            }
            else
            {
                payment.VisitInfo = null;
            }

            return payment;
        }

    }
}
