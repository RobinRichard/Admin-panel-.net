using MVCApplication;
using SMMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMMS.Models
{
    public class UserTutor
    {
        public int TutorID { get; set; }

        public int UserID { get; set; }

        [Required]
        public int UserRoleID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a tutor level.")]
        [Display(Name = "Tutor Level")]
        public Nullable<int> TutorLevelID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a date of birth.")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email address.")]
        [EmailValidate("UserID", "Email address already exists.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a street address.")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserStudent
    {
        public int UserID { get; set; }

        public int StudentID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a role.")]
        [Display(Name = "Role")]
        public int UserRoleID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a date of birth.")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email address.")]
        [EmailValidate("UserID", "Email address already exists.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a street address.")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a parent name.")]
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a parent phone number.")]
        [Display(Name = "Parent Phone Number")]
        public Nullable<int> ParentPhone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a parent email address.")]
        [Display(Name = "Parent Email Address")]
        public string ParentEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a parent street address.")]
        [Display(Name = "Parent Street Address")]
        public string ParentAddrsss { get; set; }
    }

    public class UserTechnician
    {
        public int UserID { get; set; }

        public int TechnicianID { get; set; }

        [Required]
        public int UserRoleID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a date of birth.")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email address.")]
        [EmailValidate("UserID", "Email address already exists.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a street address.")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class CustomPayroll
    {
        public int PayrollID { get; set; }

        public int UserID { get; set; }

        public Nullable<decimal> Deduction { get; set; }

        [Required]
        public decimal NetPay { get; set; }

        public System.DateTime PayDate { get; set; }

        public decimal GrossPay { get; set; }

        public string UserName { get; set; }
    }

    public class calendar
    {

        public int BatchID { get; set; }
        public string UserName { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string StartTimeHour { get; set; }
        public string StartTimeMin { get; set; }
        public string Event { get; set; }


    }
}

namespace MVCApplication
{
    public class ValidateDateDay : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)Convert.ToDateTime(value).DayOfWeek == 6)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The day should be a Saturday.");
            }
        }
    }

    public class ValidateStartTimeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if ((TimeSpan)value >= TimeSpan.Parse("08:30") && (TimeSpan)value <= TimeSpan.Parse("11:00"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The start time should be between 8.30 am and 11.00 am.");
                }
            }
            catch
            {
                return new ValidationResult("Invalid date should be in format (8:30).");
            }
        }
    }

    public class ValidateEndTimeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if ((TimeSpan)value >= TimeSpan.Parse("9:00") && (TimeSpan)value <= TimeSpan.Parse("11:30"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The start time should be between 9.00 am and 11.00 am.");
                }
            }
            catch
            {
                return new ValidationResult("Invalid date should be in format (8:30).");
            }
        }
    }

    public class ValidateIntrumentService : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                {
                    InstumentService instumentService = entity.InstumentServices.Where(f => f.InstrumentHireId == (Int32)value).FirstOrDefault();
                    if (instumentService == null)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Instrument is being serviced.");
                    }
                }
            }
            catch
            {
                return new ValidationResult("Instrument is being serviced.");
            }
        }
    }

    public class ValidateBatchCount : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                {
                    var lessonbatch = entity.Lessonbatches.Where(f => f.LessonBatchID == (Int32)value).ToList();
                    if (lessonbatch.Count < 16)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Group size has reached the maximum.");
                    }
                }
            }
            catch
            {
                return new ValidationResult("Group size has reached the maximum.");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidateInstrumentStausAttribute : ValidationAttribute
    {
        string otherPropertyName;

        public ValidateInstrumentStausAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                if (otherPropertyInfo.PropertyType.Equals(new Int32().GetType()))
                {
                    int instrumentID = (int)value;
                    int EnrolmentID = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                    {
                        InstrumentHire instrumentHire = entity.InstrumentHires.Where(f => f.InstrumentAssertID == instrumentID).FirstOrDefault();
                        if (instrumentHire.EnrolmentID == EnrolmentID)
                        {
                            return ValidationResult.Success;
                        }
                        else if (instrumentHire == null)
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("Instrument is already hired.");
                        }
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property");
                }
            }
            catch (Exception)
            {

                return new ValidationResult("Instrument is already hired.");
            }

            return validationResult;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EmailValidateAttribute : ValidationAttribute
    {
        string otherPropertyName;

        public EmailValidateAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                if (otherPropertyInfo.PropertyType.Equals(new Int32().GetType()))
                {
                    string email = (string)value;
                    int userID = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                    {
                        User datasetUser = entity.Users.Where(f => f.Email == email).FirstOrDefault();
                        if (datasetUser.UserID == userID)
                        {
                            return ValidationResult.Success;
                        }
                        else if (datasetUser == null)
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("Email address alrady exists.");
                        }
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property.");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Email address alrady exists.");
            }

            return validationResult;
        }
    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class InstrumentHireValidateAttribute : ValidationAttribute
    {
        string otherPropertyName;

        public InstrumentHireValidateAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                if (otherPropertyInfo.PropertyType.Equals(new Int32().GetType()))
                {
                    int EnrolmentID = (int)value;
                    int InstrumentAssertID = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                    {
                        Enrolment enrolment = entity.Enrolments.Where(f => f.EnrolmentID == EnrolmentID).FirstOrDefault();
                        InstrumentAssert instrumentAssert = entity.InstrumentAsserts.Where(f => f.InstrumentAssertID == InstrumentAssertID).FirstOrDefault();
                        InstrumentHire instrumentHire = entity.InstrumentHires.Where(f => f.EnrolmentID == enrolment.EnrolmentID && f.InstrumentAssertID == instrumentAssert.InstrumentAssertID).FirstOrDefault();
                        if (enrolment.Lessonbatch.Lesson.InstrumentID == instrumentAssert.InstrumentID && instrumentHire == null)
                        {
                            return ValidationResult.Success;
                        }
                        else if (enrolment.Lessonbatch.Lesson.InstrumentID != instrumentAssert.InstrumentID)
                        {
                            return new ValidationResult("Enrolment can't hire this instrument.");
                        }
                        else if (instrumentHire != null)
                        {
                            return new ValidationResult("Enrolment currently has an instrument hired.");
                        }
                        else
                        {
                            return new ValidationResult("Enrolment can't hire this instrument and currently has an instrument hired.");
                        }
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property.");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Enrolment can't hire this instrument.");
            }

            return validationResult;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class LevelConflitAttribute : ValidationAttribute
    {
        string otherPropertyName;

        public LevelConflitAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                if (otherPropertyInfo.PropertyType.Equals(new Int32().GetType()))
                {
                    int tutorID = (int)value;
                    int lessonID = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                    {
                        Tutor tutor = entity.Tutors.Where(f => f.TutorID == tutorID).FirstOrDefault();
                        Lesson lesson = entity.Lessons.Where(f => f.LessonID == lessonID).FirstOrDefault();
                        var skill = entity.InstumentLevels.Where(f => f.UserID == tutor.UserID && f.CourseLevelID > lesson.CourseLevelID && f.InstrumentID == lesson.InstrumentID).ToList();
                        if (skill.Count > 0)
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("Levels are conflicting with course and tutor.");
                        }
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property.");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Levels are conflicting with course and tutor.");
            }

            return validationResult;
        }
    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidateEnrolmentAttribute : ValidationAttribute
    {
        string otherPropertyName;
        string EnrolmentPropertyName;
        public ValidateEnrolmentAttribute(string otherPropertyName, string EnrolmentPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
            this.EnrolmentPropertyName = EnrolmentPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                var enrolmentPropertyInfo = validationContext.ObjectType.GetProperty(this.EnrolmentPropertyName);
                if (otherPropertyInfo.PropertyType.Equals(new Int32().GetType()))
                {
                    int LessonBatchID = (int)value;
                    int studentID = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                    int enromlentD = (int)enrolmentPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    using (IN705_201802_arulr1Entities1 entity = new IN705_201802_arulr1Entities1())
                    {
                        Enrolment enrolment = entity.Enrolments.Where(f => f.StudentID == studentID && f.LessonBatchID == LessonBatchID).FirstOrDefault();
                        if (enrolment == null)
                        {
                            return ValidationResult.Success;
                        }
                        else if (enrolment.EnrolmentID == enromlentD)
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("Student is already enrolled in this lesson.");
                        }
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property.");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Student is already enrolled in this lesson.");
            }

            return validationResult;
        }
    }
}