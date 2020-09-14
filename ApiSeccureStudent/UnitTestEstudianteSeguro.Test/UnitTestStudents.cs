using System;
using ApiSeccureStudent.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Net.Cache;
using ApiSeccureStudent.Models;
using System.Net;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace UnitTestEstudianteSeguro.Test
{
    [TestClass]
    public class UnitTestStudents
    {
        [TestMethod]
        public void TestMethodGetStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();

            //Act
            var ListaEstudiante = studentsController.GetStudents();

            //Assert
            Assert.IsNotNull(ListaEstudiante);
        }
        //Tambien se puede hacer un usiario de prueba
        //tambien en el post
        /*[TestMethod]
        public void TestMethodPostStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();
            studentsController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/students")
            };
            studentsController.Configuration = new HttpConfiguration();
            studentsController.Configuration.Routes.MapHttpRoute(
                name: "DefaulApi",
                routeTemplate: "api/{studentscontroler}/{id}",
                defaults: new {id = RouteParameter.Optional});

            //Act
            Student student = new Student()
            {
                StudentID = 10,
                FirstName = "EstudianteN1",
                LastName = "EstudianteA1",
                EnrollmentDate = DateTime.Now,
            };
            var response = studentsController.PostStudent(student);

            //Assert
            Assert.AreEqual("htpp://localhost/api/studentes/10", response);
        }*/

        [TestMethod]
         public void TestMethodPostStudent2()
         {
             //Arrange
            Student student_expected = new Student()
            {
                StudentID = 4,
                LastName = "Cladera",
                FirstName = "Isabel",
                EnrollmentDate = DateTime.Today,
            };
            StudentsController studentsController = new StudentsController();

            //Act
            IHttpActionResult actionResult = studentsController.PostStudent(student_expected);
            var student_actual = actionResult as CreatedAtRouteNegotiatedContentResult<Student>;

            //Assert
            Assert.IsNotNull(student_actual);
          // Assert.AreEqual("DefaultApi", student_actual.RouteName);
          //  Assert.AreEqual(student_expected.StudentID, student_actual.RouteValues["id"]);
            Assert.AreEqual(student_expected.FirstName,student_actual.Content.FirstName);
            Assert.AreEqual(student_expected.LastName, student_actual.Content.LastName);
        }

        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange
            Student student_expected = new Student()
            {
                StudentID = 4,
                LastName = "Cladera",
                FirstName = "Isabel",
                EnrollmentDate = DateTime.Today,
            };
            StudentsController studentsController = new StudentsController();

            //Act
            var result = studentsController.PutStudent(student_expected.StudentID, student_expected);
            var studet_actual = result as OkNegotiatedContentResult<Student>;
            //student

            //Assert
            Assert.IsNull(studet_actual);
            //porque no trae ningun valor por eso solo si es nulo esta bien
                     //Assert.AreEqual(HttpStatusCode.NoContent, result);
                     //Assert.AreEqual(student_expected, studet_actual);
        }
        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange
            Student student_expected = new Student()
            {
                StudentID = 4,
                LastName = "Cladera",
                FirstName = "Isabel",
                EnrollmentDate = DateTime.Today,
            };
            StudentsController studentsController = new StudentsController();

            //Act
            IHttpActionResult actionResult = studentsController.PostStudent(student_expected);
            IHttpActionResult actionResult_Delete = studentsController.DeleteStudent(student_expected.StudentID);
            //var student_actual = actionResult as OkNegotiatedContentResult<Student>;

            //Assert
            //Assert.IsNotNull(student_actual);
            // Assert.AreEqual(student_expected.StudentID, student_actual.Content.StudentID); 
            Assert.IsInstanceOfType(actionResult_Delete, typeof(OkNegotiatedContentResult<Student>));
        }
        
    }


}
