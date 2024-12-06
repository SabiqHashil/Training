using StudentJobApplication.Services;
using Microsoft.AspNetCore.Mvc;
using StudentJobApplication.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using StudentJobApplication.Helpers;

namespace StudentJobApplication.Services
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        public StudentsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        // Method: Index
        public IActionResult Index()
        {
            var students = context.Students.OrderByDescending(p => p.Id).ToList();
            return View(students);
        }
        // Method: Create (GET)
        public IActionResult Create()
        {
            return View();
        }
        // Method: Create (POST)
        [HttpPost]
        public IActionResult Create(StudentDto studentDto)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return View(studentDto);
            }
            // Validate age
            if (studentDto.DOB > DateTime.Now.AddYears(-18))
            {
                ModelState.AddModelError("DOB", "Applicant must be at least 18 years old.");
                return View(studentDto);
            }
            // Validate photo
            if (studentDto.Photo != null)
            {
                var photoExtension = Path.GetExtension(studentDto.Photo.FileName).ToLowerInvariant();
                var allowedPhotoExtensions = new[] { ".jpg", ".jpeg", ".png" };
                // Validate photo file type
                if (!allowedPhotoExtensions.Contains(photoExtension))
                {
                    ModelState.AddModelError("Photo", "Only JPG, JPEG, and PNG files are allowed.");
                    return View(studentDto);
                }
                // Validate photo file size (e.g., max 5MB)
                if (studentDto.Photo.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("Photo", "Photo file size cannot exceed 5MB.");
                    return View(studentDto);
                }
            }
            // Validate resume
            if (studentDto.Resume != null)
            {
                // Get file extension
                var resumeExtension = Path.GetExtension(studentDto.Resume.FileName).ToLowerInvariant();
                // Validate resume file type
                if (resumeExtension != ".pdf")
                {
                    ModelState.AddModelError("Resume", "Only PDF files are allowed.");
                    return View(studentDto);
                }
                // Validate resume file size (e.g., max 5MB)
                if (studentDto.Resume.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("Resume", "Resume file size cannot exceed 5MB.");
                    return View(studentDto);
                }
            }
            try
            {
                // Process Photo
                string photoBase64 = "";
                if (studentDto.Photo != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        studentDto.Photo.CopyTo(memoryStream);
                        byte[] photoBytes = memoryStream.ToArray();
                        photoBase64 = Base64Helper.ConvertToBase64(photoBytes);
                    }
                }
                // Process Resume
                string resumeBase64 = "";
                if (studentDto.Resume != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        studentDto.Resume.CopyTo(memoryStream);
                        byte[] resumeBytes = memoryStream.ToArray();
                        resumeBase64 = Base64Helper.ConvertToBase64(resumeBytes);
                    }
                }
                // student object
                Student student = new Student()
                {
                    Name = studentDto.Name,
                    Email = studentDto.Email,
                    Phone = studentDto.Phone,
                    DOB = studentDto.DOB,
                    Photo = photoBase64,
                    Resume = resumeBase64
                };
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error saving the application: {ex.Message}");
                return View(studentDto);
            }
        }
        // Method: Edit (GET)
        public IActionResult Edit(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index", "Students");
            }
            // Map student data to DTO
            var studentDto = new StudentDto
            {
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                DOB = student.DOB
            };
            // Pass the StudentId to the view
            ViewData["Photo"] = student.Photo; 
            ViewData["Resume"] = student.Resume;
            ViewData["StudentId"] = student.Id;
            return View(studentDto);
        }
        // Method: Edit(POST)
        [HttpPost]
        public IActionResult Edit(int id, StudentDto studentDto)
        {
            var student = context.Students.Find(id);
            var tempStudent = student;
            if (student == null)
            {
                return RedirectToAction("Index", "Students");
            }
            try
            {
                // Validate and update photo if provided
                if (studentDto.Photo != null)
                {
                    var photoExtension = Path.GetExtension(studentDto.Photo.FileName).ToLowerInvariant();
                    var allowedPhotoExtensions = new[] { ".jpg", ".jpeg", ".png" };

                    if (!allowedPhotoExtensions.Contains(photoExtension))
                    {
                        ModelState.AddModelError("Photo", "Only JPG, JPEG, and PNG files are allowed.");
                        ViewData["StudentId"] = student.Id;
                        return View(studentDto);
                    }
                    if (studentDto.Photo.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Photo", "Photo file size cannot exceed 5MB.");
                        ViewData["StudentId"] = student.Id;
                        return View(studentDto);
                    }
                    // Update the photo
                    using (var memoryStream = new MemoryStream())
                    {
                        studentDto.Photo.CopyTo(memoryStream);
                        byte[] photoBytes = memoryStream.ToArray();
                        student.Photo = Base64Helper.ConvertToBase64(photoBytes);
                    }
                }
                // Validate and update resume if provided
                if (studentDto.Resume != null)
                {
                    var resumeExtension = Path.GetExtension(studentDto.Resume.FileName).ToLowerInvariant();
                    if (resumeExtension != ".pdf")
                    {
                        ModelState.AddModelError("Resume", "Only PDF files are allowed.");
                        ViewData["StudentId"] = student.Id;
                        return View(studentDto);
                    }
                    if (studentDto.Resume.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Resume", "Resume file size cannot exceed 5MB.");
                        ViewData["StudentId"] = student.Id;
                        return View(studentDto);
                    }
                    // Update the resume
                    using (var memoryStream = new MemoryStream())
                    {
                        studentDto.Resume.CopyTo(memoryStream);
                        byte[] resumeBytes = memoryStream.ToArray();
                        student.Resume = Base64Helper.ConvertToBase64(resumeBytes);
                    }
                }
                // Update the resume
                using (var memoryStream = new MemoryStream())
                {
                    if(studentDto.Resume == null)
                    {
                        student.Resume = tempStudent.Resume;
                    }
                    else
                    {
                        studentDto.Resume.CopyTo(memoryStream);
                        byte[] resumeBytes = memoryStream.ToArray();
                        student.Resume = Base64Helper.ConvertToBase64(resumeBytes);
                    }
                }
                // Update other student details
                student.Name = studentDto.Name;
                student.Phone = studentDto.Phone;
                student.Email = studentDto.Email;
                student.DOB = studentDto.DOB;
                if (studentDto.Photo == null)
                    student.Photo = tempStudent.Photo;
                if (studentDto.Resume == null)
                    student.Resume = tempStudent.Resume;

                // Save changes
                context.SaveChanges();
                return RedirectToAction("Index", "Students");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating the application: {ex.Message}");
                ViewData["StudentId"] = student.Id;
                return View(studentDto);
            }
        }
        // Method: Delete
        public IActionResult Delete(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index", "Students");
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
    }
}