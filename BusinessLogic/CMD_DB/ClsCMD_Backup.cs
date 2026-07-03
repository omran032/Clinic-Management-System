using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.ClassLogs;

namespace BusinessLogic.CMD_DB
{
    public class ClsCMD_Backup
    {

        /// <summary>
        /// إرجاع تاريخ ووقت آخر نسخة احتياطية من جدول Logs
        /// يعتمد على السجل الذي يحتوي Action = 'Database Backup'
        /// </summary>
        public static DateTime? GetLastBackupDate()
        {
            string query = @"
        SELECT TOP 1 Timestamp
        FROM Logs
        WHERE Action = 'DatabaseBackup'
        ORDER BY Timestamp DESC";

            DataTable dt = ClassCommands.ShowData(query);

            if (dt.Rows.Count == 0)
                return null;

            return Convert.ToDateTime(dt.Rows[0]["Timestamp"]);
        }


        /// <summary>
        /// إرجاع حجم ملف معيّن بالميغابايت
        /// </summary>
        public static double GetFileSizeMB(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;

            FileInfo fileInfo = new FileInfo(filePath);

            // الحجم بالميغابايت
            return Math.Round((double)fileInfo.Length / (1024 * 1024), 2);
        }



        #region ****  عمليات النسخ  ****

        /// <summary>
        /// التحقق من صحة مسار النسخة الاحتياطية
        /// </summary>
        public static bool IsValidBackupPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            // إذا كان مجلد وليس ملف
            string dir = Path.GetDirectoryName(path);

            return Directory.Exists(dir);
        }




        /// <summary>
        /// يقوم بإنشاء نسخة احتياطية من ملف قاعدة البيانات MDF
        /// اعتماداً على المسار الموجود في مجلد المستندات.
        /// </summary>
        /// <param name="backupPath">المسار الكامل للنسخة الاحتياطية المطلوبة</param>
        /// <returns>true إذا نجح النسخ، false إذا فشل</returns>
        public static bool BackupDatabase(string backupPath)
        {
            try
            {
                // مسار ملف الـ MDF
                string mdfPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    @"Clinic Management\Database\ClinicSystemDB.mdf"
                );

                if (!File.Exists(mdfPath))
                    return false;

                // 1) إغلاق جميع الاتصالات
                SqlConnection.ClearAllPools();

                // 2) الانتظار لحظة حتى يفلت LocalDB الملف
                System.Threading.Thread.Sleep(500);

                // 3) نسخ الملف
                File.Copy(mdfPath, backupPath, overwrite: true);

                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// إنشاء اسم ملف النسخة الاحتياطية مع التاريخ والوقت
        /// </summary>
        public static string GenerateBackupFilePath(string folderPath)
        {
            string fileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            return Path.Combine(folderPath, fileName);
        }


        /// <summary>
        /// تسجيل عملية النسخ الاحتياطي في جدول Logs
        /// </summary>
        public static void LogBackupOperation(int userId, string backupPath)
        {
            ClassLogs.AddLog(userId, LogAction.UpdateDoctor.ToString(), "Backup", 0, $"تم إنشاء نسخة احتياطية في: {backupPath}" );
        }

        /// <summary>
        /// فتح نافذة اختيار مجلد وإرجاع المسار المختار
        /// </summary>
        public static string SelectBackupFolder()
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "اختر المجلد الذي تريد حفظ النسخة الاحتياطية بداخله";

                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.SelectedPath;
            }

            return string.Empty;
        }



      

        #endregion




    }
}
