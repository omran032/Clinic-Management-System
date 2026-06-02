using BusinessLogic.InfoTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Clinic_Management.Patients.UControls
{
    public partial class Ctrl_PatientInfo : UserControl
    {
        public Ctrl_PatientInfo()
        {
            InitializeComponent();
         
        }

        // معلومات المريض كاملة
      private  ClassPatients PatientsInfo_;

      public  ClassPatients PatientsInfo
        {
            get { return PatientsInfo_; }
            set
            {
                if (value == null) return;

                PatientsInfo_ = value;

                LoadData(PatientsInfo_);
            }
        }

        void LoadData( ClassPatients Patient )
        {
            // معلومات الشخصية
            if(Patient.PersonInfo != null)
               ctrl_PersonInfo1.PersonInfo = Patient.PersonInfo;

            lblFirstVisitDate.Text         = "Date of the first visit : " + Patient.FirstVisitDate;
            lbl_StatusComplianceScore.Text = "Commitment Status : " + Patient.StatusComplianceScore;
            lbl_ComplianceScore.Text       = "Degree of commitment : " + Patient.ComplianceScore;

            Ctrl_MedicalNotes.InfoText    = Patient.MedicalNotes;
            Ctrl_ChronicDiseases.InfoText = Patient.ChronicDiseases;
            Ctrl_Allergies.InfoText       = Patient.Allergies;
            Ctrl_Notes.InfoText           = Patient.Notes;
        }

    }
}
