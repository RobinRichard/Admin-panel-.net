//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMMS.Models
{
    using MVCApplication;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Enrolment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enrolment()
        {
            this.Payments = new HashSet<Payment>();
            this.InstrumentHires = new HashSet<InstrumentHire>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a student enrolment.")]
        [Display(Name = "Student Enrolment")]
        public int EnrolmentID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a student.")]
        [Display(Name = "Student")]
        public int StudentID { get; set; }

        [ValidateEnrolment("StudentID", "EnrolmentID", "Student is already enrolled in this lesson.")]
        [ValidateBatchCount]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a lesson batch.")]
        [Display(Name = "Lesson Batch")]
        public int LessonBatchID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a date.")]
        [Display(Name = "Date")]
        public System.DateTime Date { get; set; }

        public virtual Student Student { get; set; }

        public virtual Lessonbatch Lessonbatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstrumentHire> InstrumentHires { get; set; }
    }
}
